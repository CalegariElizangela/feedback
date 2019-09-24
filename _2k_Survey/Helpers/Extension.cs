using _2k_Shared;
using _2k_Shared.Views;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2k_Survey.Helpers
{
    public static class Extension
    {
        public static string GetParamsByName(this AuthorizationFilterContext mvcContext, string name)
            => ((DefaultHttpContext)mvcContext.HttpContext).Request.Query[name].ToString();

        public static HtmlString GetSurvey(this IHtmlHelper helper, SurveyViewModel model)
        {
            var html = SurveyBuilder.GetInstance(model).GetHTML();

            return new HtmlString(html);
        }
    }
}
