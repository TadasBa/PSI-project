using Android.App;
using Android.Icu.Text;
using Pantry.enums;
using Pantry.models;
using Pantry.models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAccount : Popup
    {
        LoginService _loginService;
        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterCheck CheckDetails = new RegisterCheck();
        public EditAccount(User user)
        {
            BindingContext = this;
            User = user;
            Name = user.Name;
            Email = user.Email;
            Password = "";
            _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();

        }

        public async void BtnUpdate(object sender, EventArgs args)
        {
            if (Email != null && Name != null)
            {
                if (Regex.IsMatch(Name, @"^[a-zA-Z\s]+$") == false)
                {
                    await App.Current.MainPage.DisplayAlert("Invalid username", "Please enter letters only", "Close");

                }
                else if (!CheckDetails.CheckIfEmailCorrect(Email))
                {
                    await App.Current.MainPage.DisplayAlert("Invalid email", "Please enter correct email", "Close");
                }
                else
                {
                    if(Password == "")
                    {
                        Password = "N/A";
                    }

                    _loginService.UpdateUser(User, Name, Email, Password);
                    ((MainPage)Application.Current.MainPage).DisplayToast("Saving changes");
                    Dismiss("Updated");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please fill all the fields", "Close");
            }
        }

        public void BtnCancel(object sender, EventArgs args)
        {
            Dismiss("Canceled");
        }
    }
}