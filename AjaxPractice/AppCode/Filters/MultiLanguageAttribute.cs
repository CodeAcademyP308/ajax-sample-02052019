using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AjaxPractice
{
    public class MultiLanguageAttribute : FilterAttribute, IActionFilter
    {
        private static string _cookieLangName = "LangForMultiLanguageDemo";

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string cultureOnCookie = GetCultureOnCookie(context.HttpContext.Request);

            string culture = context.RouteData.Values.ContainsKey("lang")
                ? context.RouteData.Values["lang"].ToString() : "";

            if (string.IsNullOrWhiteSpace(culture) || string.IsNullOrWhiteSpace(cultureOnCookie))
            {
                culture = string.IsNullOrWhiteSpace(cultureOnCookie) ? Extension.DefaultCulture : cultureOnCookie;

                var langCookie = new HttpCookie(_cookieLangName);
                langCookie.Expires = DateTime.Now.AddDays(5);
                langCookie.Value = culture;
                context.HttpContext.Response.Cookies.Add(langCookie);

                context.HttpContext.Response.RedirectToRoute("LocalizedDefault",
                new
                {
                    lang = culture,
                    controller = context.RouteData.Values["controller"],
                    action = context.RouteData.Values["action"]
                });
                return;
            }

            SetCurrentCultureOnThread(culture);

            if (culture != MultiLanguageViewEngine.CurrentCulture)
                (ViewEngines.Engines[0] as MultiLanguageViewEngine).SetCurrentCulture(culture);
        }

        private static void SetCurrentCultureOnThread(string lang)
        {
            if (string.IsNullOrEmpty(lang))
                lang = Extension.DefaultCulture;

            var cultureInfo = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        public static String GetCultureOnCookie(HttpRequestBase request)
        {
            var cookie = request.Cookies[_cookieLangName];
            string culture = string.Empty;
            if (cookie != null)
            {
                culture = cookie.Value;
            }
            return culture;
        }
    }
}