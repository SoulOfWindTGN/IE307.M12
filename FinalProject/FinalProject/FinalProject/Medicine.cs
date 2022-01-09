using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class Medicine
    {
        [PrimaryKey, AutoIncrement]
        public int MedicineID { get; set; }
        public int UserID { get; set; }
        public string MedicineName { get; set; } // Tên thuốc
        public string Date { get; set; } // Ngày bắt đầu nhắc nhở uống thuốc
        public int Number { get; set; } //Liều lượng thuốc
        public string Unit { get; set; } // Đơn vị liều
        public string Time { get; set; } // Thời gian nhắc nhở
    }
}
