using DotNet.Utilities;
using MyWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        [Gzip]
        public ActionResult Index()
        {
            return View();
        }
        [Gzip]
        public ActionResult Education()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Gzip]
        public ActionResult Work()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Gzip]
        public ActionResult FuturePlan()
        {
            ViewBag.Message = "Your contact page.";
             
            return View();
        }

        public ActionResult DownResume() {
            var strPath = "/Content/ress/梁泽祥简历.docx";
            string filePath = Server.MapPath(strPath);//路径      
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
            if (fileInfo.Exists == true)
            {

                return File(filePath, "application/octet-stream", "梁泽祥2019年简历.docx");
            }
            else
            {
                JsHelper.AlertAndGoHistory("简历暂时不见了，请您QQ联系我哦", -1);
                return null;
            }

        }
    }
}