using Plugin.Geolocator;
using TravelRecordApp.Logic;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelRecordAppPage : ContentPage
    {
        public TravelRecordAppPage()
        {
            InitializeComponent();

            var assembly = typeof(TravelRecordAppPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);

        }


        void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }

        }

        void regsiterButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegsiterPage());
        }
    }
}
