using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class WeightHistory
    {
        [PrimaryKey,AutoIncrement]
        public int weighthistoryID { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public double BMI { get; set; }
        public double FatRatio { get; set; }
        public int Weight { get; set; }
    }
}
