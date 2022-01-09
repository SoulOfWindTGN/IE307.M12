using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class History
    {
        [PrimaryKey, AutoIncrement]
        public int HistoryID { get; set; } //Mã hoạt động
        public int UserID { get; set; }
        public string ActivityName { get; set; } // Tên hoạt động vd: Uống nước
        public string Detail { get; set; } //Chi tiết vd: 5ml
        public string Time { get; set; } //Thời gian hoạt động
    }
}
