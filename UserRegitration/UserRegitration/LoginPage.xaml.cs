using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UserRegitration
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

        async void LoginClicked(System.Object sender, System.EventArgs e)
        {
            await SQLiteHelp.Init();

            string email = Email.Text;
            string password = Password.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            var user = await SQLiteHelp.Login(email, password);
            var existingUser = await SQLiteHelp.GetUserByEmail(email);

            if (user != null)
            {
                LoadingOverlay.Show();

                Login.IsEnabled = false;

                await Task.Delay(1500);

                LoadingOverlay.Hide();

                Application.Current.MainPage = new NavigationPage(new UserPage(user.Name, user.Email));
            }

            else if(existingUser == null)
            {
                await DisplayAlert("Login", "Email not present Register to Login", "OK");
                return;
            }

            else
            {
                await DisplayAlert("Login", "Invalid Email or Password", "OK");
                Password.Text = string.Empty;
                return;
            }

            Email.Text = string.Empty;
            Password.Text = string.Empty;
        }


        async void RegisterClicked(System.Object sender, System.EventArgs e)
        {
            LoadingOverlay.Show();

            await Task.Delay(1500);

            LoadingOverlay.Hide();

            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}

