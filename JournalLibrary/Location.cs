using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    //Class inherits from the database, allows class to use all Database functions
    public class Location:Database
    {
        //Set properties for the class
        public int ID { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //Method to create new location for entries
        public void NewLocation()
        {
            ExecuteQueries($@"INSERT INTO [dbo].[Location]
         ([UserID]
          ,[City]
          ,[State])
          Values('{User.ID}','{City}', '{State}');");
        }

        //Method that list previous locations from the user
        public List<Location> SelectLocation()
        {
            Output output = new Output();
            return output.GetLocations(User);
        }

        //Method allows user to update locations on entries
        public void UpdateLocation()
        {
            ExecuteQueries($@"UPDATE [dbo].[Location]
             SET 
            ,[City] = '{City}'
            ,[State] = '{State}'
            WHERE LocationID = '{ID}';");
        }
    }
}
