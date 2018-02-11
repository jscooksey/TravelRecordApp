using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegsiterPage : ContentPage
    {
        public RegsiterPage()
        {
            InitializeComponent();
        }

        void registerButton_Clicked(object sender, System.EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                
            }
            else
            {
                DisplayAlert("Register Failed","Passwords do not match","OK");
            }
        }
    }
}
