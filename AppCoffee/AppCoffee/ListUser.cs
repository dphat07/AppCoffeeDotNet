using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    public class ListUser
    {
        private static ListUser instance;

        public static ListUser Instance
        {
            get
            { 
                if (instance == null)
                    instance = new ListUser();
                return instance;
            }
            set => instance = value;
        }


        List<User> lstUser;

        public List<User> LstUser 
        { 
            get => lstUser;
            set => lstUser = value; 
        }

        ListUser()
        {
            lstUser = new List<User>();
            lstUser.Add(new User("ducphat", "123456"));
            lstUser.Add(new User("dinhtien", "123456"));
            lstUser.Add(new User("nhaquan", "123456"));
            lstUser.Add(new User("giahuy", "123456"));
        }
    }
}
