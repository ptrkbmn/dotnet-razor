using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace pbdev.Razor.TagHelpers
{
  [HtmlTargetElement("fa")]
  public class FontAwesomeTagHelper : TagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      var content = await output.GetChildContentAsync();
      output.TagName = "i";
      output.Attributes.SetAttribute("class", String.Format("fas fa-{0} fa-fw", content.GetContent().ToLowerInvariant()));
      output.Content.SetContent(String.Empty);
    }
  }

  [HtmlTargetElement("fa2")]
  public class FontAwesomeTagHelper2 : TagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      var content = await output.GetChildContentAsync();
      output.TagName = "i";
      output.Attributes.SetAttribute("class", String.Format("fas fa-{0}", content.GetContent().ToLowerInvariant()));
      output.Content.SetContent(String.Empty);
    }
  }
}
