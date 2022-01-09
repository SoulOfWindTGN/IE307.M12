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
    public partial class EditProfilePage : ContentPage
    {
        User user;
        public EditProfilePage()
        {
            InitializeComponent();
        }

        public EditProfilePage(User user)
        {
            InitializeComponent();
            user_account.Text = user.UserName;
            user_password.Text = user.UserPassword;
            check_password.Text = user.UserPassword;
            user_name.Text = user.UserFullName;
            user_birthday.Date = DateTime.Parse(user.UserDateOfBirth);
            user_weight.Text = user.UserWeight.ToString();
            user_height.Text = user.UserHeight.ToString();
            if(user.UserGender=="Nam")
            {
                male.IsChecked = true;
                female.IsChecked = false;
            }
            else
            {
                male.IsChecked = false;
                female.IsChecked = true;
            }
            this.user = user;
        }

        private void saveprofile_Clicked(object sender, EventArgs e)
        {
            if (user_password.Text == null || check_password.Text == null || user_name.Text == null || user_weight.Text == null || user_height.Text == null)
            {
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin", "Xác nhận");
            }
            else
            {
                if (user_password.Text != check_password.Text)
                {
                    DisplayAlert("Thông báo", "Mật khẩu không khớp", "Xác nhận");
                }
                else
                {
                    Database db = new Database();
                    User u = this.user;
                    u.UserPassword = user_password.Text;
                    u.UserFullName = user_name.Text;
                    u.UserDateOfBirth = user_birthday.Date.ToString("dd/MM/yyyy");
                    if (male.IsChecked)
                        user.UserGender = "Nam";
                    else
                        user.UserGender = "Nữ";
                    user.UserHeight = Int32.Parse(user_height.Text);
                    user.UserWeight = Int32.Parse(user_weight.Text);

                    //update
                    if(db.UpdateUserInfos(u))
                    {
                        DisplayAlert("Thông báo", "Thay đổi thành công", "Xác nhận");
                        this.user = u;
                        Navigation.PushAsync(new HealthCarePage(this.user));
                    }
                    else
                    {
                        DisplayAlert("Thông báo", "Thay đổi thất bại", "Xác nhận");
                    }
                }
            }
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}