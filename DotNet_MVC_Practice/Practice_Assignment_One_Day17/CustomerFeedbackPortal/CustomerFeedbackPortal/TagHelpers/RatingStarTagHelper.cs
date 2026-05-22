using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace CustomerFeedbackPortal.TagHelpers
{
    [HtmlTargetElement("rating-stars")]
    public class RatingStarTagHelper : TagHelper
    {
        public int MaxStars { get; set; } = 5;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= MaxStars; i++)
            {
                sb.Append($"<span style='font-size:30px;color:gold;'>★</span>");
            }
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
