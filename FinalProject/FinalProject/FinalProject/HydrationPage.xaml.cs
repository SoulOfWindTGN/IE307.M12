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
    public partial class HydrationPage : ContentPage
    {
        public HydrationPage()
        {
            InitializeComponent();
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            age.Text = "";
            weight.Text = "";
            height.Text = "";
            male.IsChecked = true;
            female.IsChecked = false;
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (age.Text == null || weight.Text == null || height.Text == null)
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin", "Xác nhận");
            else
            {
                int Age = Int32.Parse(age.Text);
                double Weight = float.Parse(weight.Text);
                double Height = float.Parse(height.Text);
                double TBW;

                if (male.IsChecked)
                {
                    TBW = 2.447 - 0.09516 * Age + 0.1074 * Height + 0.3362 * Weight;
                }
                else
                {
                    TBW = -2.097 + 0.1069 * Height + 0.2466 * Weight;
                }
                DisplayAlert("Lượng nước trong cơ thể", Math.Round(TBW,2).ToString() + "Lít", "Trở lại");
            }
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Nước trong cơ thể", "Tổng lượng nước cơ thể tạo thành gần 65% trọng lượng cơ thể đối với một người đàn ông " +
                "trưởng thành khỏe mạnh và 55% trọng lượng cơ thể đối với một người phụ nữ khỏe mạnh. Nước đóng vai trò rất quan trọng trong việc " +
                "tham gia cấu tạo các tế bào và cơ quan tổ chức, cũng như duy trì các hoạt động bình thường trong cơ thể. Khi cơ thể chúng ta mất " +
                "10% nước thì đã lâm vào tình trạng bệnh lý, mất từ 20 - 25% nước là đã có thể chết.", "Trở lại");
        }
    }
}