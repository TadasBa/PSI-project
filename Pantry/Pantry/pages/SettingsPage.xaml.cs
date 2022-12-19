using Android.Telephony;
using Pantry.models;
using Pantry.models.Login;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        static Switch wSwitch = new Switch();
        static Switch nSwitch = new Switch();
        private LoginService _loginService;

        public SettingsPage()
        {
            _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        private void GoToLogin(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }



        public static void WarningsOn(DateTime t)
        {
            if (wSwitch.IsToggled)
            {
                if (SelectColor.GetDaysLeft(t, DateTime.Now) < 1)
                {
                    LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(expiryDate: t, titleName: "WARNING", "You added product that will expire soon"));
                }
            }
        }

        public void warningSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            wSwitch.IsToggled = e.Value;
        }


        public static void NotificationsOn(DateTime t)
        {
            if (nSwitch.IsToggled)
            {
                LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(t, titleName: "Notification"));
            }
        }

        private void notificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            nSwitch.IsToggled = e.Value;
        }

        private async void OnEditAccount(object sender, EventArgs e)
        {
            _ = await Navigation.ShowPopupAsync(new EditAccount(_loginService.currentUser));
        }

        private async void OnDeleteAccount(object sender, EventArgs e)
        {
            bool result = await App.Current.MainPage.DisplayAlert("Delete account", "The account will be deleted", "Delete", "Close");
            if (result)
            {
                _loginService.RemoveUser(_loginService.currentUser);
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}