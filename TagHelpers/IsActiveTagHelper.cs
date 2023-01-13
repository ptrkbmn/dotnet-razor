
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace pbdev.Razor.TagHelpers
{
  [HtmlTargetElement(Attributes = "is-active")]
  public class ActiveClassTagHelper : AnchorTagHelper
  {
    public ActiveClassTagHelper(IHtmlGenerator generator) : base(generator) { }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      var routeData = ViewContext.RouteData.Values;
      var currentController = routeData["controller"] as string;
      var currentAction = routeData["action"] as string;
      var result = false;

      if (!String.IsNullOrWhiteSpace(Controller) && !String.IsNullOrWhiteSpace(Action))
        result = String.Equals(Action, currentAction, StringComparison.OrdinalIgnoreCase) &&
            String.Equals(Controller, currentController, StringComparison.OrdinalIgnoreCase);
      else if (!String.IsNullOrWhiteSpace(Action))
        result = String.Equals(Action, currentAction, StringComparison.OrdinalIgnoreCase);
      else if (!String.IsNullOrWhiteSpace(Controller))
        result = String.Equals(Controller, currentController, StringComparison.OrdinalIgnoreCase);

      if (result)
      {
        string? existingClasses = null;
        if (output.Attributes["class"] != null)
        {
          existingClasses = output.Attributes["class"]?.Value.ToString();
          output.Attributes.Remove(output.Attributes["class"]);
        }
        output.Attributes.Add("class", $"{existingClasses} active");
      }
    }
  }
}