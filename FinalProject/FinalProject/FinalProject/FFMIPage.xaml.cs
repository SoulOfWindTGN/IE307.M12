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
    public partial class FFMIPage : ContentPage
    {
        public FFMIPage()
        {
            InitializeComponent();
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            body_fat.Text = "";
            height.Text = "";
            weight.Text = "";
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            double Weight = double.Parse(weight.Text);
            double Height = double.Parse(height.Text)/100;
            double BodyFat = double.Parse(body_fat.Text);
            double FFM = Weight * (1 - BodyFat / 100);
            double FFMI = FFM / (Height * Height);
            DisplayAlert("FFMI", Math.Round(FFMI, 2).ToString(), "Trở lại");
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("FFMI", "Fat Free Mass Index (FFMI) là thước đo mức độ cơ bắp của chúng ta. Xét về khái niệm, chỉ số FFMI sẽ tương tự với BMI " +
                ". Tuy nhiên, thay vì đo lượng sự liên quan tổng trọng lượng cơ thể với chiều cao, thì FFMI lại đo lường sự liên quan giữa khối lượng " +
                "cơ bắp với chiều cao.", "Trở lại");
        }
    }
}