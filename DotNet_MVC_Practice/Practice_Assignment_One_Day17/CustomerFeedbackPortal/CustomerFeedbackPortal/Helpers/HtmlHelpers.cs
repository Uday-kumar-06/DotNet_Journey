using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerFeedbackPortal.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent StyledInput(this IHtmlHelper htmlHelper,
            string name,
            string placeholder)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("name", name);
            input.Attributes.Add("placeholder", placeholder);
            input.AddCssClass("form-control");
            input.AddCssClass("mb-3");
            return input;
        }
    }
}
