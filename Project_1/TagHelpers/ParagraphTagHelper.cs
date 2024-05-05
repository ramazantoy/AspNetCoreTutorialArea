using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Project_1.TagHelpers
{
    [HtmlTargetElement("paragraph")]
    public class ParagraphTagHelper : TagHelper
    {
        
        public string ShortDescription { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<b>Custom tag helper works {ShortDescription}</b>");
            base.Process(context, output);
        }
    }
}