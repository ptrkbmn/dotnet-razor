using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbdev.Razor
{
  public struct LanguageInfo
  {
    public string Code { get; set; }
    public string Label { get; set; }
    public string Flag { get; set; }

    public static readonly IDictionary<string, LanguageInfo> LanguageInfos = new Dictionary<string, LanguageInfo>()
    {
      { "de", new LanguageInfo() { Code = "de", Label = "Deutsch (German)", Flag = "de" } },
      { "en", new LanguageInfo() { Code = "en", Label = "English", Flag = "gb" } },
    };

    public static LanguageInfo Get(string code) => LanguageInfos[code];
  }
}
