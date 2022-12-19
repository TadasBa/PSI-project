using Android.OS;
using Android.Views.Accessibility;
using Newtonsoft.Json;
using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Pantry.models.Login
{
    public class LoginService : ILoginService
    {
        public User currentUser { get; set; }
        private HttpClient _client = new HttpClient();
        public LoginService()
        {
            _client.BaseAddress = new Uri("http://elvinosas.lt");
        }
        
        public async Task<bool> Login(User user)
        {

            try
            {
                Application.Current.MainPage.DisplayToastAsync("Logging in...", 1000);

                StringContent c = new StringContent(JsonConvert.SerializeObject(user), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await _client.PostAsync("http://elvinosas.lt/auth/login/", c);
                m.EnsureSuccessStatusCode();

                Application.Current.MainPage.DisplayToastAsync(Style.ToastSuccess);

                string result = await m.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(result);

                currentUser = user;
                return true;
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
                Application.Current.MainPage.DisplayToastAsync("Failed to log in...", 1000);
                return false;
            }

        }
        

        public async Task AddUser(User user)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Creating user...", 1000);

                StringContent c = new StringContent(JsonConvert.SerializeObject(user), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await _client.PostAsync("http://elvinosas.lt/auth/register/", c);
                m.EnsureSuccessStatusCode();
               

                Application.Current.MainPage.DisplayToastAsync(Style.ToastSuccess);

                string result = await m.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(result);

            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
                Application.Current.MainPage.DisplayToastAsync("Failed to create user...", 1000);
            }
        }

        public async Task RemoveUser(User user)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Removing user...", 1000);
                HttpResponseMessage m = await _client.DeleteAsync("http://elvinosas.lt/auth/delete/" + user.Id);
                m.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
                Application.Current.MainPage.DisplayToastAsync("Failed to remove user...", 1000);
            }
        }

        public async Task UpdateUser(User user, string name, string email, string password)
        {
            user.Name = name;
            user.Email = email;
            user.Password = password;

            try
            {
                Application.Current.MainPage.DisplayToastAsync("Updating user...", 1000);
                StringContent c = new StringContent(JsonConvert.SerializeObject(user), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await _client.PutAsync("http://elvinosas.lt/auth/user/" + user.Id, c);
                m.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
                Application.Current.MainPage.DisplayToastAsync("Failed to update user...", 1000);
            }
        }

    }
}
