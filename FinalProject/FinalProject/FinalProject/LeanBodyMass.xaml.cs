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
    public partial class LeanBodyMass : ContentPage
    {
        public LeanBodyMass()
        {
            InitializeComponent();

            gender.Items.Add("Nam");
            gender.Items.Add("Nữ");
            gender.SelectedIndex = 0;

            metric.Items.Add("Tính theo Boer Formula");
            metric.Items.Add("Tính theo Boer James Formula");
            metric.Items.Add("Tính theo Boer Hume Formula");
            metric.SelectedIndex = 0;
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Lean Body Mass", "LBM viết tắt của Lean Body Mass. Dịch ra có nghĩa là khối lượng cơ thể nạc săn chắc. Khối lượng LBM" +
                " được tạo thành từ các yếu tố như: cơ quan nội tạng, máu, nước, xương, da và cơ bắp. LBM là một thành phần trong body composition " +
                "và chúng thường được gọi tắt là lean mass.", "Trở lại");
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (age.Text == null || weight.Text == null || height.Text == null)
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin", "Xác nhận");
            else
            {
                int Age = Int32.Parse(age.Text);
                double Weight = float.Parse(weight.Text);
                double Height = float.Parse(height.Text) / 100;
                int Gender = gender.SelectedIndex;
                int Metric = metric.SelectedIndex;
                String Result;

                if(Metric == 0)
                {
                    if(Gender==0)
                        Result = Math.Round(0.407 * Weight + 0.267 * Height - 19.2, 2).ToString() + " kg";
                    else
                        Result = Math.Round(0.252 * Weight + 0.267 * Height - 19.2, 2).ToString() + " kg";
                }
                else if (Metric == 1)
                {
                    Result = Math.Round(1.1 * Weight - 128 * (Weight/Height) * (Weight / Height), 2).ToString() + " kg";
                }
                else
                {
                    Result = Math.Round(0.32810 * Weight + 0.33929 * Height - 29.5336, 2).ToString() + " kg";
                }
            }
        }
    }
}