using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    class Location
    {
        public int ID { get; set; }
        public User UserID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
