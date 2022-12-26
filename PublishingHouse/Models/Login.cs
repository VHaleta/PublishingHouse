using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Login
    {
        public const string Id_ = "ID_PrintingHouse";
        public const string Password_ = "Password";
        public const string Username_ = "Login";
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Login() { }
        public Login(int Id, string Username, string Password)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
        }
        
    }
}
