using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<HttpClient>();
            DependencyService.Register<IDataHandler, DataHandlerAPI>();

            MainPage = new MainPage();
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
