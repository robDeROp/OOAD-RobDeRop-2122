using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class User
    {
        string Fname { get; set; }
        string Lname { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Function { get; set; }
        public bool UserCheck(User user)
        {
            
            bool UserExists = false;
            int c = 0;
            if (c > 0)
            {
                UserExists = true;
            }
            else
            {
                UserExists = false;

            }
            return UserExists;
        }
    }

}
