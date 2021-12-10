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
    public partial class BasalMetabolicRatePage : ContentPage
    {
        public BasalMetabolicRatePage()
        {
            InitializeComponent();
            metric.Items.Add("Ít vận động");
            metric.Items.Add("Tập thể dục từ 1-3/tuần");
            metric.Items.Add("Tập thể dục từ 3-5/tuần");
            metric.Items.Add("Tập thể dục mỗi ngày");
            metric.Items.Add("Vận động cường độ cao");
            metric.SelectedIndex = 0;
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
                int Metric = metric.SelectedIndex;
                double BMR, Calories;

                if (female.IsChecked)
                {
                    BMR = 655.1 + (9.563 * Weight) + (1.85 * Height) - (4.676 * Age);
                }
                else
                {
                    BMR = 66.47 + (13.75 * Weight) + (5.003 * Height) - (6.755 * Age);
                }

                if (Metric == 0)
                    Calories = Math.Round(BMR * 1.2, 2);
                else if (Metric == 1)
                    Calories = Math.Round(BMR * 1.375, 2);
                else if (Metric == 2)
                    Calories = Math.Round(BMR * 1.55, 2);
                else if (Metric == 3)
                    Calories = Math.Round(BMR * 1.725, 2);
                else
                    Calories = Math.Round(BMR * 1.9, 2);
                DisplayAlert("BMR và calo cần thiết mỗi ngày", null, "Tỷ lệ trao đổi chất cơ bản: " + BMR.ToString()
                    + "\nCalo cần thiết mỗi ngày (Calories): " + Calories.ToString(), "Trở lại");
            }
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            age.Text = "";
            weight.Text = "";
            height.Text = "";
            male.IsChecked = true;
            female.IsChecked = false;
            metric.SelectedIndex = 0;
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Lean Body Mass", "Tỷ lệ trao đổi chất cơ bản (basal metabolic rate) là lượng calo mà cơ thể sử dụng để thực hiện các" +
                " chức năng cơ bản như: hít thở, tuần hoàn máu, chuyển hóa chất dinh dưỡng, tạo tế bào mới. Biết được chỉ số BMR, mức độ hoạt động " +
                "và lượng calo cơ thể cần hàng ngày để duy trì cân nặng là những bước quan trọng để điều chỉnh chế độ ăn uống cho phù hợp.", "Trở lại");
        }
    }
}