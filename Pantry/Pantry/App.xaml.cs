using Pantry.pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pantry.models.Login;

namespace Pantry
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ILoginService, LoginService>(); 

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
