using System;
using Xamarin.Forms;

namespace HelloApp
{
    public partial class PhonePage : ContentPage
    {
        public PhonePage()
        {
            InitializeComponent();
        }

        private void SavePhone(object sender, EventArgs e)
        {
            var phone = (Phone)BindingContext;
            if (!String.IsNullOrEmpty(phone.Title))
            {
                App.Database.SaveItem(phone);
            }
            this.Navigation.PopAsync();
        }
        private void DeletePhone(object sender, EventArgs e)
        {
            var phone = (Phone)BindingContext;
            App.Database.DeleteItem(phone.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}