using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class WaterHisory
    {
        [PrimaryKey, AutoIncrement]
        public int whID { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public float AmountWater { get; set; }
        public string Image { get; set; }
    }
}
