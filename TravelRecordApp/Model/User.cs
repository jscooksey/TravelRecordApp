using System;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async void Insert(User user)
        {
            await App.MobileService.GetTable<User>().InsertAsync(user);
        }

        public static async Task<bool> Login(string emailEntry, string passwordEntry)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == passwordEntry)
                        return true;
                    else
                        return false;
                }
                else return false;
            }

        }

    }
}
