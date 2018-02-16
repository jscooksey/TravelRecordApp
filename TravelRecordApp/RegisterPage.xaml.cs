using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, System.EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                User user = new User()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

                User.Insert(user);
            }
            else
            {
                await DisplayAlert("Register Failed","Passwords do not match","OK");
            }
        }
    }
}
