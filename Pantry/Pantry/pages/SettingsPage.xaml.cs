using Pantry.models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void GoToLogin(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }


        public void WarningsOn(DateTime t)
        {
            bool switchState = warningSwitch.IsToggled;

            if (switchState)
            {
                if (SelectColor.GetDaysLeft(t) < 1)
                {
                    LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(t, titleName: "WARNING", "You added product that will expire soon"));
                }
            }
        }
    }
}