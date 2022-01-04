using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class CaloriesHistory
    {
        [PrimaryKey, AutoIncrement]
        public int chID { get; set; }
        public int userID { get; set; }
        public string image_meal { get; set; }
        public string meal { get; set; }
        public int calories { get; set; }
        public string date { get; set; }
    }
}
