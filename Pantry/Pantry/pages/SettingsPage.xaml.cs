using Pantry.models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        static Switch wSwitch = new Switch();
        static Switch nSwitch = new Switch();

        public SettingsPage()
        {
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
                if (SelectColor.GetDaysLeft(t) < 1)
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
            if(nSwitch.IsToggled)
            {
                LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(t, titleName: "Notification"));
            }
        }

        private void notificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            nSwitch.IsToggled = e.Value;
        }
    }
}