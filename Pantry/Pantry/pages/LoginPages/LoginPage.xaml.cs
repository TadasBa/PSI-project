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
        LoginService _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);

        public LoginPage()
        {
            InitializeComponent();
            _loginService = new LoginService();
        }

        public bool CheckUserDetails(string username, string password)
        {
            return _loginService.CheckUserDetails(username, password);
        }

        private void GoToRegister(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private void BtnGoToMain(object sender, EventArgs e)
        {
            if(CheckUserDetails(usernameEntry.Text,passwordEntry.Text) == true)
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