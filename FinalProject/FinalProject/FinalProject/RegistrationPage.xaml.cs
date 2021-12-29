using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void regist_Clicked(object sender, EventArgs e)
        {
            if (username.Text == null || password.Text == null || check_password.Text == null || name.Text == null || weight.Text == null ||
                height.Text==null)
            {
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin đăng ký", "Xác nhận");
            }
            else
            {
                Database db = new Database();
                if (db.checkUsername(username.Text) == false)
                {
                    DisplayAlert("Thông báo", "Tên đăng nhập đã trùng", "OK");
                }
                else if (password.Text == check_password.Text)
                {
                    User user = new User();
                    user.UserName = username.Text;
                    user.UserPassword = password.Text;
                    user.UserFullName = name.Text;
                    user.UserDateOfBirth = birthday.Date.ToString("dd/MM/yyyy");
                    if (male.IsChecked)
                        user.UserGender = "Nam";
                    else
                        user.UserGender = "Nữ";
                    user.UserHeight = Int32.Parse(height.Text);
                    user.UserWeight = Int32.Parse(weight.Text);
                    user.UserTargetWater = 0;
                    user.UserTargetWeight = 0;

                    if (db.addUser(user))
                    {
                        DisplayAlert("Thông báo", "Đăng ký thành công", "Xác nhận");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Thông báo", "Đăng ký thất bại", "Xác nhận");
                    }
                }
                else
                {
                    DisplayAlert("Thông báo", "Mật khẩu không khớp", "Xác nhận");
                }
            }
        }
    }
}