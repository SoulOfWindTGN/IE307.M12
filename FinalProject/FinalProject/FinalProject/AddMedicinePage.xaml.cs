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
    public partial class AddMedicinePage : ContentPage
    {
        User user = new User();
        public AddMedicinePage()
        {
            InitializeComponent();
        }

        public AddMedicinePage(User user)
        {
            InitializeComponent();
            this.user = user;

        }

        private void save_Clicked(object sender, EventArgs e)
        {
            if(m_name.Text == null || m_number.Text == null || m_unit.Text ==null)
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin", "Xác nhận");
            else
            {
                Database db = new Database();
                Medicine m = new Medicine();
                History h = new History();

                m.UserID = user.UserID;
                m.MedicineName = m_name.Text;
                m.Date = m_begindate.ToString();
                m.Number = Int32.Parse(m_number.Text);
                m.Unit = m_unit.Text;
                m.Time = m_time.ToString();

                h.UserID = user.UserID;

                h.ActivityName = "Thêm nhắc nhở thuốc";
                h.Detail = m.MedicineName;
                DateTime date = DateTime.Now;
                h.Time = date.ToString();
                if (db.addMedicine(m) && db.addHistory(h))
                {
                    DisplayAlert("Thông báo", "Thêm thành công", "Xác nhận");
                    Navigation.PopAsync();
                }
                else
                    DisplayAlert("Thông báo", "Thêm thất bại", "Xác nhận");
            }
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}