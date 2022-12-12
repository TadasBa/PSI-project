using Pantry.models;
using Pantry.models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginService _loginService;

        public LoginPage()
        {
            _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        private void GoToRegister(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private async void BtnGoToMain(object sender, EventArgs e)
        {
            User user = new User("N/A", passwordEntry.Text, emailEntry.Text);
            var result = await _loginService.Login(user);

            if (result)
            {
                lblWrongDetails.TextColor = Color.White;
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                lblWrongDetails.TextColor = Color.Red;
            }
            
        }
    }
}