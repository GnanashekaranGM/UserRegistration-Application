using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using UserRegitration.Model;
using UserRegitration.Controls;

namespace UserRegitration
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await SQLiteHelp.Init();

            string name = Name.Text;
            string email = Email.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            var existingUser = await SQLiteHelp.GetUserByEmail(email);
            if (existingUser != null)
            {
                await DisplayAlert("Error", "Email already exists", "OK");
                return;
            }

            var user = new UserDetails
            {
                Name = name,
                Email = email,
                Password = password
            };

            await SQLiteHelp.AddUser(user);

            await DisplayAlert("Success", "Registration successful! Redirecting to Login Page", "OK");

            LoadingOverlay.Show();

            await Task.Delay(1500);

            LoadingOverlay.Hide();

            Application.Current.MainPage = new NavigationPage(new LoginPage());

            Name.Text = string.Empty;
            Email.Text = string.Empty;
            Password.Text = string.Empty;
            ConfirmPassword.Text = string.Empty;
        }

        private async void OnSignInClicked(System.Object sender, System.EventArgs e)
        {
            LoadingOverlay.Show();

            await Task.Delay(1500);

            LoadingOverlay.Hide();

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}

