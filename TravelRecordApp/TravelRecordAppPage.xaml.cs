using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class TravelRecordAppPage : ContentPage
    {
        public TravelRecordAppPage()
        {
            InitializeComponent();
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

    }
}
