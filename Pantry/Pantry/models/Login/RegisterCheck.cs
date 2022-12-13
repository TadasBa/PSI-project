using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Pantry.models.Login
{
    public class RegisterCheck
    {
       LoginService _loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);

        public bool CheckIfEmailCorrect(string email)
        {
            if(Regex.IsMatch(email, "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfEntriesAreNotNull(string email, string username, string password)
        {
            if (email == null || username == null || password == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
