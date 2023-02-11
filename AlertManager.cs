using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace pbdev.Razor;

public class AlertManager
{
  private ISession _session;
  private List<Alert> _alerts;

  public AlertManager(ISession session)
  {
    _session = session;

    string alertsJson = _session.GetString(nameof(AlertManager));
    if (!String.IsNullOrEmpty(alertsJson))
      _alerts = JsonSerializer.Deserialize<List<Alert>>(alertsJson) ?? new List<Alert>();
    else
      _alerts = new List<Alert>();
  }

  public IEnumerable<Alert> Alerts() => _alerts;

  public void Add(Alert alert) => _alerts.Add(alert);

  public void Success(string message, string? title = null)
    => Add(new Alert() { Title = title, Message = message, AlertType = AlertType.Success });

  public void Warning(string message, string? title = null)
    => Add(new Alert() { Title = title, Message = message, AlertType = AlertType.Warning });

  public void Error(string message, string? title = null)
    => Add(new Alert() { Title = title, Message = message, AlertType = AlertType.Error });

  public void Error(Exception exception) => Error(exception.Message);

  public void Info(string message, string? title = null)
    => Add(new Alert() { Title = title, Message = message, AlertType = AlertType.Info });

  public void Debug(string message, string? title = null)
    => Add(new Alert() { Title = title, Message = message, AlertType = AlertType.Debug });

  public void Save()
    => _session.SetString(nameof(AlertManager), JsonSerializer.Serialize(_alerts));

  public void Clear() => _alerts.Clear();
}

public class Alert
{
  public string? Title { get; set; }

  public string? Message { get; set; }

  public AlertType AlertType { get; set; } = AlertType.Info;

  public string BootstrapAlert
  {
    get
    {
      switch (AlertType)
      {
        case AlertType.Error: return "danger";
        case AlertType.Debug: return "light";
        default: return AlertType.ToString().ToLowerInvariant();
      }
    }
  }
}

public enum AlertType
{
  Success,
  Warning,
  Error,
  Info,
  Debug,
}