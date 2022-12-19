using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pantry.models.Login
{
    public interface ILoginService
    {
        User currentUser { get; set; }
        Task<bool> Login(User user);
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task UpdateUser(User user, string username, string email, string password);

    }
}
