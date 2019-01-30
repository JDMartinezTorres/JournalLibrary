using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    public class Entry:Database
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Location Location{ get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EntryDate { get; set; }

        public void NewEntry()
        {
            ExecuteQueries($@"INSERT INTO [dbo].[Entries]
           ([UserID]
           ,[LocationID]
           ,[Title]
           ,[EntryText]
           ,[EntryDate])
            Values('{User.ID}','{Location.ID}','{Title}','{Text}','{EntryDate.ToShortDateString()}');");
        }

        public List<Entry>GetEntry(User user)
        {
            Output output = new Output();
            return output.GetEntry(user);
        }

        public void UpdateEntry()
        {
            ExecuteQueries($@" Update [dbo].[Entries]
            SET [Title] = '{Title}',
                [EntryText] = '{Text}',
                [EntryDate] = '{EntryDate}'
            WHERE [Entries].[UserID] = '{User.ID}';");
        }
    }
}
