using ModelsLibrary.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.AuthenticationService
{
    public class UserAuthenticationService
    {
        public User AuthenticateUser(string userName, string password)
        {
            string json = string.Empty;
            string filePath = "Data/Users.json";
            json = File.ReadAllText(filePath);
            var listUsers = JsonConvert.DeserializeObject<List<User>>(json);
            return listUsers.FirstOrDefault(u => u.Password == password && u.UserName.ToLower() == userName.ToLower());
        }
    }
}
