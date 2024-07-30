using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    public class User
    {
        private string nameUser;

        private string passwordUser;

        public string NameUser 
        {
            get => nameUser;
            set => nameUser = value; 
        }
        public string PasswordUser 
        { 
            get => passwordUser; 
            set => passwordUser = value; 
        }

        public User (string nameUser, string passwordUser)
        {
            this.nameUser = nameUser;
            this.passwordUser = passwordUser;
        }
    }
}
