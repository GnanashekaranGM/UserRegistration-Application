using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UserRegitration
{	
	public partial class UserPage : ContentPage
	{	
		public UserPage (string name, string email)
		{
			InitializeComponent ();

            NameLabel.Text = name;
            EmailLabel.Text = email;
        }

        async void LogoutClicked(System.Object sender, System.EventArgs e)
        {
            LoadingOverlay.Show();

            await Task.Delay(1500);

            LoadingOverlay.Hide();

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}