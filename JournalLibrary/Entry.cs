﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    class Entry
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Location Location{ get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}