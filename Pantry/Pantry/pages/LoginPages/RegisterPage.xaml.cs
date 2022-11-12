using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pantry.models.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterCheck CheckDetails = new RegisterCheck();

        public RegisterPage()
        {
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
            else if(CheckDetails.CheckIfUserIsNotTaken(NewUsername.Text)==false)
            {
                lblRegisterFailed.TextColor = Color.Red;
                lblRegisterFailed.Text = "Username already taken";
            }
            else
            {
                CheckDetails.NewUserData(NewEmail.Text, NewUsername.Text, NewPassword.Text);
                Application.Current.MainPage = new LoginPage();
            }


                
        }
            
    }
}