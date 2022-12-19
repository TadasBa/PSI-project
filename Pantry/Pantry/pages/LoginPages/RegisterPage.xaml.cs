using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pantry.models;
using Pantry.models.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterCheck CheckDetails = new RegisterCheck();
        LoginService _loginService;

        public RegisterPage()
        {
            _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        private void GoToLogin(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
        private void BtnAddUser(object sender, EventArgs e)
        {
            if (CheckDetails.CheckIfEntriesAreNotNull(NewEmail.Text, NewUsername.Text, NewPassword.Text) == false)
            {
                lblRegisterFailed.TextColor = Color.Red;
                lblRegisterFailed.Text = "You haven't filled out  all the requirements";
            }
            else if (CheckDetails.CheckIfEmailCorrect(NewEmail.Text) == false)
            {
                lblRegisterFailed.TextColor = Color.Red;
                lblRegisterFailed.Text = "Try again with a valid email adress";
            }
            else
            {
                User user = new User(NewUsername.Text, NewPassword.Text, NewEmail.Text);
                _loginService.AddUser(user);
                Application.Current.MainPage = new LoginPage();
            }


                
        }
            
    }
}