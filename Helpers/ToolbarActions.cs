
namespace pbdev.Razor.Helpers
{
  public class ActionGroup
  {
    public ActionGroup(ActionItem[] actions, string? cssClass = null)
    {
      Actions = actions;
      CssClass = cssClass;
    }

    public ActionItem[] Actions { get; private set; }

    public string? CssClass { get; set; }
  }

  public class ActionItem
  {
    protected ActionItem(string title, string icon)
    {
      Title = title;
      Icon = icon;
    }

    public ActionItem(string title, string icon, string controller, string action, object? routeValues = null, string? cssClass = null)
     : this(title, icon)
    {
      Controller = controller;
      Action = action;
      RouteValues = routeValues;
      CssClass = cssClass;
    }

    public string Title { get; set; }

    public string Icon { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public object? RouteValues { get; set; }

    public string? CssClass { get; set; }

    public bool IsJS { get; set; }
  }

  public class SubmitFormActionItem : ActionItem
  {
    public SubmitFormActionItem(string title, string icon, string formId) : base(title, icon)
    {
      FormId = formId;
    }

    public string FormId { get; set; }
  }
}
