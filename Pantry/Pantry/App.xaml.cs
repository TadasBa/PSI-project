using Pantry.pages;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pantry.models.Login;
using Android.Content.PM;
using Android.OS;
using Android;
using Castle.DynamicProxy;
using Pantry.Utilities.Interceptor;

namespace Pantry
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var proxy = new ProxyGenerator();
            DependencyService.Register<LoginService, LoginService>();
            DependencyService.Register<HttpClient>();
            DependencyService.RegisterSingleton(proxy.CreateInterfaceProxyWithTarget<IDataHandler<EventArgs>>(new DataHandlerAPI(), new DataHandlerInterceptor()));
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
