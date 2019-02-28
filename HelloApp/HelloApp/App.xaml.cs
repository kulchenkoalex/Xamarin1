using System;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloApp
{
    public partial class App : Application
    {
        public static string settingsPath = System.IO.Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Personal), "settings.xml");
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
            Language language = new Language("en");

            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Language));
            // получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream(settingsPath, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, language);
            //}

            // десериализация
            //using (FileStream fs1 = new FileStream(settingsPath, FileMode.Open))
            //{
            //    Language newLanguage = (Language)formatter.Deserialize(fs1);
            //}
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }


    // класс и его члены объявлены как public
    [Serializable]
    public class Language
    {
        public static string Localize { get; set; }

        // стандартный конструктор без параметров
        public Language()
        { }

        public Language(string localize)
        {
            Localize = localize;
        }
    }
}