using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            if (db.checkLoginUser(username.Text, password.Text))
            {
                Navigation.PushAsync(new HealthCarePage());
            }
            else
            {
                DisplayAlert("Thông báo", "Sai thông tin đăng nhập", "Xác nhận");
            }
        }

        private void regist_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
