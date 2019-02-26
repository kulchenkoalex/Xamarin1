using System.Globalization;

namespace HelloApp
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
