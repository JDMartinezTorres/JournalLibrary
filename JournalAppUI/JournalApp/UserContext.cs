using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalLibrary;

namespace JournalApp
{
    public class UserContext
    {
        public static User User { get; set; }
        public static bool PasswordCorrect(User user)
        {
            if (User != null)
            {
                if (User.Password != user.Password)
                {
                    return false;
                }
                if (User.Password == user.Password)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
