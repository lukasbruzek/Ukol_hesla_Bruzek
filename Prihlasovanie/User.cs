using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prihlasovanie
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public override string ToString()
        {
             return string.Format("{0,-50}", UserName);
        }

        public User(string username, string password, bool isAdmin)
        {
            this.UserName = username;
            this.Password = password;
            this.isAdmin = isAdmin;
        }

        public User()
        {

        }
    }
}
