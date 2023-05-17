using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_dotnet_full_webapi.Models
{
    public class User
    {
        static public List<User> List = new List<User>();
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string? username, string? password)
        {
            Id = List.Count;
            Username = username ?? new StringBuilder().Append("user").Append(Id).ToString();
            Password = password ?? new StringBuilder().Append("password").Append(Id).ToString();
        }
    }
}
