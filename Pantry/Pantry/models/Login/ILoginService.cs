using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.Login
{
    public interface ILoginService
    {
        bool CheckUserDetails(string username, string password);
    }
}
