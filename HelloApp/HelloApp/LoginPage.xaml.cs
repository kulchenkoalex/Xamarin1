using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private string emailAdmin = "a";
        private string passwordAdmin = "1";

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (emailEntry.Text == emailAdmin && passwordEntry.Text == passwordAdmin)
            {
                Navigation.PushAsync(new MenuPage());
            }
            else
            {

            }
        }
    }
}