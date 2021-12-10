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
        public string UserName { get; set; } // Tên đăng nhập
        public string UserPassword { get; set; } // Mật khẩu
        public string UserFullName { get; set; } //Tên hiển thị trong ứng dụng
        public string UserDateOfBirth { get; set; } // Ngày sinh
        public string UserGender { get; set; } // Giới tính
        public int UserWeight { get; set; } // Cân nặng
        public int UserHeight { get; set; } // Chiều cao
    }
}
