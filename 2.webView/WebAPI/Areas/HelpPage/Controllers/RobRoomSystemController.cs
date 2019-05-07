using System;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI;
namespace WebAPI.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class RobRoomSystemController : Controller
    {
        private const string ErrorViewName = "Error";

        public RobRoomSystemController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public RobRoomSystemController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        { 
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

    
    }
}