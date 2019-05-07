using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI;
namespace WebAPI.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {

            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            var config = Configuration.Services.GetApiExplorer().ApiDescriptions;

            return View(config);

        }

        public ActionResult Api(string apiId)
        {

            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    if (apiModel.ResourceProperties == null) return View(apiModel);

                    foreach (var item in apiModel.ResourceProperties)
                    {
                        if (item.Name == "Content" && item.TypeDescription != null)
                        {
                            var propertyList = new WebAPI.ComplexTypeModelDescription();
                            try
                            {
                                if (item.TypeDescription.ModelType.Namespace == "System")
                                {
                                    //如果是字符串 bool 这些类型(不是对象,数组之类的)则直接返回
                                    break;
                                }
                                //model
                                propertyList = (WebAPI.ComplexTypeModelDescription)item.TypeDescription;
                            }
                            catch (Exception ex)
                            {

                                if (item.TypeDescription.ModelType.IsValueType == true) break;  //如果是字符串 bool 这些类型(不是对象,数组之类的)则直接返回
                                                                                                //List
                                var list = (WebAPI.CollectionModelDescription)item.TypeDescription;
                                propertyList = (WebAPI.ComplexTypeModelDescription)list.ElementDescription;

                            }
                            var DTODescription = propertyList.ModelType;
                            var property = DTODescription.GetProperties();
                            if (propertyList.IsAddDescription == false)
                            {
                                foreach (var index in propertyList.Properties)
                                {
                                    foreach (var pro in property)
                                    {
                                        if (index.Name == pro.Name)
                                        {

                                            var Attribut = pro.GetCustomAttributesData();
                                            if (Attribut != null && Attribut.Count > 0)
                                            {
                                                foreach (var attr in Attribut)
                                                {
                                                    if (attr.AttributeType.Name == "DescriptionAttribute")
                                                    {
                                                        index.Documentation = attr.ConstructorArguments[0].Value.ToString();
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                propertyList.IsAddDescription = true;
                            }

                        }
                    }
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}