using System.Linq;
using TravelRecordApp.Model;
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


        private async void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            /* bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
             bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

             if (isEmailEmpty || isPasswordEmpty)
             {

             }
             else
             {
                 var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();
                 if(user != null)
                 {
                     App.user = user;
                     if(user.Password == passwordEntry.Text)
                         await Navigation.PushAsync(new HomePage());
                     else
                         await DisplayAlert("Error","User or password are incorrect","OK"); 
                 }
                 else
                 {
                     await DisplayAlert("Error","User or password are incorrect","OK");    
                 }
             } */

            var canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);
            if(canLogin)
                await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("Error", "User or password are incorrect", "OK");
        }

        void registerButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
