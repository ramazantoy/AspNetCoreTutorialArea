using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Project_3.Web.Data.Context;

namespace Project_3.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount : TagHelper
    {

        public int ApplicationUserId { get; set; }
        private readonly BankContext _bankContext;

        public GetBankAccountCount(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _bankContext.Accounts.Count(x => x.ApplicationUserId == ApplicationUserId);
            
            var html = $"<span class=' badge bg-danger'>{accountCount} </span>";
            output.Content.SetHtmlContent(html);
            base.Process(context, output);
        }
    }
}