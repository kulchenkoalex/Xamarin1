using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloApp
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<Grouping<string, Phone>> PhoneGroups { get; set; }

        public MainPage()
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            currentTime.Text = thisDay.ToString("d");
        }

        protected override void OnAppearing()
        {
            var phones = App.Database.GetItems();
            var groups = phones.GroupBy(p => p.Company).Select(g => new Grouping<string, Phone>(g.Key, g));          
            PhoneGroups = new ObservableCollection<Grouping<string, Phone>>(groups);
            phonesList.ItemsSource = PhoneGroups;
            this.BindingContext = this;
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Phone selectedPhone = (Phone)e.SelectedItem;
            PhonePage phonePage = new PhonePage();
            phonePage.BindingContext = selectedPhone;
            await Navigation.PushAsync(phonePage);
        }
        // обработка нажатия кнопки добавления
        private async void CreatePhone(object sender, EventArgs e)
        {
            Phone phone = new Phone();
            PhonePage phonePage = new PhonePage();
            phonePage.BindingContext = phone;
            await Navigation.PushAsync(phonePage);
        }

        //public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    Phone selectedPhone = e.Item as Phone;
        //    if (selectedPhone != null)
        //        await DisplayAlert("Выбранная модель", $"{selectedPhone.Company} - {selectedPhone.Title}\n" + "Цена - " +$"{selectedPhone.Price} "+"грн.", "OK");
        //}

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    //await DisplayAlert("Информация","Данные о телефонах обновлены успешно!","OК");

                    IsRefreshing = false;
                });
            }
        }

        private void Lang_Clicked(object sender, EventArgs e)
        {
            if (App.localize == "en")
            {
                App.localize = "ru";
            }
            else
            {
                App.localize = "en";
            }

            Navigation.PushAsync(new MainPage());
        }
    }

}