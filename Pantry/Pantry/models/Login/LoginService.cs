using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.Login
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {

        }

        public bool CheckUserDetails(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
