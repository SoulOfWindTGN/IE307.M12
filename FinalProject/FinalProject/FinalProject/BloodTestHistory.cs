using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class BloodTestHistory
    {
        [PrimaryKey, AutoIncrement]
        public int bthID { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public double Index { get; set; }
    }
}
