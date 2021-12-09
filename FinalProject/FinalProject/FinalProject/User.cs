using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
