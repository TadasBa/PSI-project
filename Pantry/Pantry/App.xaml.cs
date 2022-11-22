using Pantry.pages;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pantry.models.Login;
using Android.Content.PM;
using Android.OS;
using Android;

namespace Pantry
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ILoginService, LoginService>();
            DependencyService.Register<HttpClient>();
            DependencyService.Register<IDataHandler, DataHandlerAPI>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            IDataHandler dataHandler = DependencyService.Get<IDataHandler>(DependencyFetchTarget.GlobalInstance);
            dataHandler.GetProducts(0);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
