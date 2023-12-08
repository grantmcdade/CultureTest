using System.Globalization;

namespace CultureTest.Models;

public class CultureSwitcherModel
{
    public CultureInfo CurrentUICulture { get; set; }
    public List<CultureInfo> SupportedCultures { get; set; }
}
