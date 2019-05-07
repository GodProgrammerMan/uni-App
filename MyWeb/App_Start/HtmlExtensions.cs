using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MyWeb.App_Start
{
    /// <summary>
    /// 部分视图js渲染
    /// </summary>
    public static class HtmlExtensions
    {
        private const string JscriptDeferRazorViewdata = "__jsdfrz";
        private const string JscriptIncludeViewdata = "__jsrq";

        public static void DeferScript(this HtmlHelper html, string scriptLocation)
        {
            string jsTag = "<script type=\"text/javascript\" src=\"" + scriptLocation + "\"></script>";

            var jscripts = html.ViewContext.TempData[JscriptIncludeViewdata] as List<string> ?? new List<string>();
            if (!jscripts.Contains(jsTag))
            {
                jscripts.Add(jsTag);
            }
            html.ViewContext.TempData[JscriptIncludeViewdata] = jscripts;
        }

        public static MvcHtmlString Script(this HtmlHelper html, Func<int, HelperResult> script)
        {
            var jsActions = html.ViewContext.TempData[JscriptDeferRazorViewdata] as List<Func<int, HelperResult>> ?? new List<Func<int, HelperResult>>();
            jsActions.Add(script);
            html.ViewContext.TempData[JscriptDeferRazorViewdata] = jsActions;
            return MvcHtmlString.Empty;
        }

        public static IHtmlString RenderScripts(this HtmlHelper html)
        {
            var jscripts = html.ViewContext.TempData[JscriptIncludeViewdata] as List<string>;
            var jsActions = html.ViewContext.TempData[JscriptDeferRazorViewdata] as List<Func<int, HelperResult>>;
            html.ViewContext.TempData[JscriptIncludeViewdata] = new List<string>();
            html.ViewContext.TempData[JscriptDeferRazorViewdata] = new List<Func<int, HelperResult>>();
            return new HelperResult(writer =>
            {
                if (jscripts != null)
                {
                    writer.Write(string.Join("\r\n", jscripts.ToArray()));
                }
                if (jsActions != null) foreach (var action in jsActions) { action(0).WriteTo(writer); }
            });
        }
    }
}