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
    public partial class BodyFatPage : ContentPage
    {
        public BodyFatPage()
        {
            InitializeComponent();
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Tỷ lệ chất béo cơ thể", "Để xác định tỷ lệ mỡ trong cơ thể, bạn không thể nhìn vào gương hoặc bước lên bàn cân. Một người tập thể hình và" +
                " một người béo phì có thể có cùng trọng lượng, nhưng họ có tỷ lệ mỡ cơ thể khác nhau. Cân nặng của bạn không thể cho bạn biết " +
                "lượng cơ bắp hoặc lượng chất béo bạn có. Thay vào đó, bạn cần xác định tỷ lệ phần trăm mỡ cơ thể.", "Trở lại");
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
                double Height = float.Parse(height.Text) / 100;
                double BMI = Math.Round(Weight / (Height * Height), 2);
                double BFP;

                if (male.IsChecked)
                {
                    BFP = 1.20 * BMI + 0.23 * Age - 16.2;
                }
                else
                {
                    BFP = 1.20 * BMI + 0.23 * Age - 5.4;
                }
                DisplayAlert("Tỷ lệ chất béo cơ thể", Math.Round(BFP, 2).ToString() + " (%)", "Trở lại");
            }
        }
    }
}