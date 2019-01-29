using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalLibrary;

namespace Library_Tester
{
    class TestView
    {
        Database Journal = new Database();

        public void Execute()
        {
            try
            {
                User user = new User()
                {
                    ID = 2,
                    UserName = "JDMartinez",
                    Password = "Password",
                    LastName = "Martinez",
                    FirstName = "Juan",
                    MI = "D"
                };
                //user.NewUser();

                Location location = new Location()
                {
                   User = user
                };
                //location.NewLocation();

                Entry entry = new Entry()
                {
                    User = user
                };

            foreach (var  ent in entry.GetEntry(user))
            {
                    Console.WriteLine($"{ent.Location.City} {ent.Location.State}");
            }        

                Console.WriteLine("Method executed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
                Console.ReadLine();

        }
    }
}