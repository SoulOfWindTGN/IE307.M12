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
    public partial class BMI : ContentPage
    {
        public BMI()
        {
            InitializeComponent();
            gender.Items.Add("Nam");
            gender.Items.Add("Nữ");
            gender.SelectedIndex = 0;
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("BMI", "BMI - chỉ số khối cơ thể là một con số có nguồn gốc từ cân nặng và chiều cao của một người." +
                " BMI được sử dụng để đo lường chất béo cơ thể. BMI đã được đề nghị để đánh giá thừa cân và béo phì ở trẻ em và thanh thiếu niên.", 
                "Trở lại");
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (age.Text == null || weight.Text == null || height.Text == null)
                DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin", "Xác nhận");
            else 
            {
                int Age = Int32.Parse(age.Text);
                double Weight = float.Parse(weight.Text);
                double Height = float.Parse(height.Text)/100;
                int Gender = gender.SelectedIndex;

                double BMI = Math.Round(Weight / (Height * Height), 2);
                string Result = BMI.ToString();
                if (Age >= 20)
                {
                    if(BMI < 18.5)
                    {
                        Result = Result + " - Thiếu cân";
                    }
                    else if (BMI >= 18.5 && BMI < 25)
                    {
                        Result = Result + " - Cân đối";
                    }
                    else
                    {
                        Result = Result + " - Thừa cân";
                    }
                }
                else if (Age <= 10)
                {
                    if(Gender == 0)
                    {
                        if (BMI < 14)
                        {
                            Result = Result + " - Thiếu cân";
                        }
                        else if (BMI >= 14 && BMI <= 19)
                        {
                            Result = Result + " - Cân đối";
                        }
                        else
                        {
                            Result = Result + " - Thừa cân";
                        }
                    }
                    else
                    {
                        if (BMI < 18.5)
                        {
                            Result = Result + " - Thiếu cân";
                        }
                        else if (BMI >= 14 && BMI <= 21)
                        {
                            Result = Result + " - Cân đối";
                        }
                        else
                        {
                            Result = Result + " - Thừa cân";
                        }
                    }
                }
                else
                {
                    if (Gender == 0)
                    {
                        if (BMI < 17)
                        {
                            Result = Result + " - Thiếu cân";
                        }
                        else if (BMI >= 17 && BMI <= 23)
                        {
                            Result = Result + " - Cân đối";
                        }
                        else
                        {
                            Result = Result + " - Thừa cân";
                        }
                    }
                    else
                    {
                        if (BMI < 16.8)
                        {
                            Result = Result + " - Thiếu cân";
                        }
                        else if (BMI >= 16.8 && BMI <= 22)
                        {
                            Result = Result + " - Cân đối";
                        }
                        else
                        {
                            Result = Result + " - Thừa cân";
                        }
                    }
                }
                DisplayAlert("BMI", Result, "Xác nhận");
            }
        }
    }
}