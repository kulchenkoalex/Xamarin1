using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "phones.db";
        public static PhoneRepository database;
        public static PhoneRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new PhoneRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}