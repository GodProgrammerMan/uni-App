using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 文件上传模块(所有文件上传统一入口)
    /// </summary>
    [RoutePrefix("api/FileUpload")]
    public class FileUploadController : ApiController
    {

        /// <summary>
        /// 文件上传（统一文件上传接口） ,返回集合文件路径
        /// </summary>
        /// <returns></returns>
        [Route("SetFileUpload")]
        [HttpPost]
        public Task<JSONResult<List<string>>> SetFileUpload()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            try
            {
                //先创建物理目录路径 AppDomain.CurrentDomain.BaseDirectory +
                string filepath = HttpContext.Current.Server.MapPath("/Upload/");//   
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                if (!Directory.Exists(filepath + @"\day_" + DateTime.Now.ToString("yyMMdd") + ""))
                {
                    Directory.CreateDirectory(filepath + @"\day_" + DateTime.Now.ToString("yyMMdd") + "");
                }
                //设置虚拟路径    
                string virtualPath = "~/UpLoadFile";
                var path = AppDomain.CurrentDomain.BaseDirectory;    //获取当前获取当前应用程序所在目录的路径     
                if (!Directory.Exists(path + "UpLoadFile"))      //判断是否存在该路径
                {
                    Directory.CreateDirectory(path + "UpLoadFile");  //创建路径  （主要用于存储文件)
                }
                //文件保存目录路径      先把图片放到虚拟路径下
                string dirTempPath = HttpContext.Current.Server.MapPath(virtualPath);
                // 设置上传目录 
                var provider = new MultipartFormDataStreamProvider(dirTempPath);    // 设置保存图片文件路径
                                                                                    //var queryp = Request.GetQueryNameValuePairs();//获得查询字符串的键值集合 

                var task = Request.Content.ReadAsMultipartAsync(provider).
                    ContinueWith<JSONResult<List<string>>>(T =>
                    {
                        var model = new JSONResult<List<string>>();
                        model.ret = 4;
                        model.Success = false;
                        model.Result = "上传错误";
                        var file = provider.FileData;//provider.FormData 
                        var Images = new List<string>();

                        for (int i = 0; i < file.Count; i++)
                        {
                            string orfilename = file[i].Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                            FileInfo fileinfo = new FileInfo(file[i].LocalFileName);
                            //最大文件大小 
                            int maxSize = 10000000;
                            if (fileinfo.Length <= 0)
                            {

                                model.ret = 1;
                                model.Result = "请选择上传文件";
                            }
                            else if (fileinfo.Length > maxSize)
                            {
                                model.ret = 1;
                                model.Result = "上传文件大小超过限制";
                            }
                            else
                            {

                                string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));

                                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                fileinfo.CopyTo(Path.Combine(dirTempPath, newFileName + fileExt), true);        //把当前图片复制一份，并以正常类型来命名 
                                File.Move(dirTempPath + @"\" + newFileName + fileExt, filepath + @"\day_" + DateTime.Now.ToString("yyMMdd") + @"\" + newFileName + fileExt); //把图片移动到公共公用的路径下
                                fileinfo.Delete();  //删除前图片 
                                                    //更新用户信息
                                try
                                {
                                    var imgpath = @"/Upload/day_" + DateTime.Now.ToString("yyMMdd") + "/" + newFileName + fileExt;
                                    Images.Add(imgpath);
                                    model.ret = 0;
                                    model.Success = true;
                                    model.Result = "上传成功";
                                    model.Content = Images;  //返回内容包是图片路径
                                }
                                catch (Exception ex)
                                {
                                    model.ret = 1;
                                    model.Success = false;
                                    model.Result = "上传失败" + ex.Message;
                                }
                            }
                        }

                        return model;
                    });

                return task;
            }
            catch (Exception ee)
            {
                File.AppendAllText(HttpContext.Current.Server.MapPath("/log/notify.txt"), ee.ToString() + " \r\n");
                return null;
            }
        }
    }
}