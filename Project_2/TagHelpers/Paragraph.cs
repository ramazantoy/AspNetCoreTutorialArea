using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Project_2.TagHelpers{

    
    public class Paragraph : TagHelper{

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent("<p> Leon Brave </p>");
        }
    }

}