using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class SleepHistory
    {
        [PrimaryKey, AutoIncrement]
        public int shID { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
