using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DotNet.Utilities
{
    public class log
    {
        /// <summary>
        /// 日志写入
        /// </summary>
        /// <param name="path">路径 如 c://log</param>
        /// <param name="filename">名称 如 log.txt</param>
        /// <param name="msg">消息</param>
        public static void WriteLog(string path, string filename,string msg)
        {
            string sFilePath = path  ;
            string sFileName = filename ;
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ":   " + msg);
            sw.Close();
            fs.Close();
            sw.Dispose();
            fs.Dispose();
        }
    }
}
