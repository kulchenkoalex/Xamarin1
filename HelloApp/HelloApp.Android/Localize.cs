using HelloApp;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(HelloApp.Droid.Localize))]
 
namespace HelloApp.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }

    }
}