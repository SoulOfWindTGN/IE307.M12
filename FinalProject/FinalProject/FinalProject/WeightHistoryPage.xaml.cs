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
    public partial class WeightHistoryPage : ContentPage
    {
        User user;
        public WeightHistoryPage()
        {
            InitializeComponent();
        }
        public WeightHistoryPage(User user)
        {
            InitializeComponent();
            this.user = user;
            UpdateValue();
        }
        private void UpdateValue()
        {
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date.Text = myDate;
            if(this.user.UserTargetWeight != 0)
            {
                target.Text = "Trọng lượng mục tiêu: " + this.user.UserTargetWeight + " Kg";
            }
            int IdealWeight = CalculateIdealWeight();
            double BMI = CalculateBMI();
            double BFP = CalculateFatRatio();
            ideal_weight.Text = IdealWeight.ToString() + " Kg";
            bmi.Text = BMI.ToString();
            fat_ratio.Text = BFP.ToString();

            Database db = new Database();
            List<WeightHistory> wh_list = db.getLastTenWeight(this.user.UserID);
            if(wh_list.Count!=0)
            {
                int min_index, max_index = 0;
                double max_value = 0;
                double average_value = 0;
                double min_value = 1000000;
                for (int i = 0; i < wh_list.Count(); i++)
                {
                    double index_num = wh_list[i].Weight;
                    average_value += index_num;
                    if (index_num < min_value)
                    {
                        min_value = index_num;
                        min_index = i;
                    }
                    if (index_num > max_value)
                    {
                        max_value = index_num;
                        max_index = i;
                    }
                }
                average_value /= wh_list.Count();

                last_record.Text = wh_list[0].Weight.ToString() + " Kg";
                average.Text = Math.Round(average_value, 3).ToString() + " Kg";
                min.Text = Math.Round(min_value, 3).ToString() + " Kg";
                max.Text = Math.Round(max_value, 3).ToString() + " Kg";
            }
        }
        private double CalculateBMI()
        {
            int Weight = (int)weight_scale.Value;
            double Height = (double)this.user.UserHeight / 100;
            double BMI = Math.Round(Weight / (Height * Height), 2);
            return BMI;
        }
        private int CalculateIdealWeight()
        {
            int Height = this.user.UserHeight;
            double OverHeight = 0.032808398950131 * Height - 5;
            double IBW;
            if (OverHeight > 0)
                OverHeight *= 12;
            else
                OverHeight = 0;
            if (this.user.UserGender == "Nam")
            {
                IBW = 50 + 2.3 * OverHeight;
            }
            else
            {
                IBW = 45.5 + 2.3 * OverHeight;
            }
            return (int)Math.Round(IBW);
        }
        private double CalculateFatRatio()
        {
            double BMI = CalculateBMI();
            double BFP;
            var BirthYear = DateTime.Parse(this.user.UserDateOfBirth).Year;
            var CurrentYear = DateTime.Now.Year;
            int Age = CurrentYear - BirthYear;
            if (this.user.UserGender == "Nam")
            {
                BFP = 1.20 * BMI + 0.23 * Age - 16.2;
            }
            else
            {
                BFP = 1.20 * BMI + 0.23 * Age - 5.4;
            }
            return Math.Round(BFP,2);
        }
        private async void edit_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Thay đổi trọng lượng mục tiêu", 
                "Nhập trọng lượng mục tiêu (Kg)", initialValue: "50", keyboard: Keyboard.Numeric);
            if(result != null)
            {
                if(double.Parse(result) > 0)
                {
                    int weight = (int)Math.Round(double.Parse(result));
                    Database db = new Database();
                    db.changeTargetWeight(this.user.UserID,weight);
                    this.user.UserTargetWeight = weight;
                    target.Text = "Trọng lượng mục tiêu: " + weight + " Kg";
                }
                else
                {
                    await DisplayAlert("Thông báo", "Vui lòng nhập giá trị lớn hơn 0", "OK");
                }
            }
        }

        private void weight_scale_ValueChanging(object sender, Syncfusion.SfRangeSlider.XForms.ValueEventArgs e)
        {
            float range = e.Value;
            weight.Text = range.ToString();
            double BMI = CalculateBMI();
            double BFP = CalculateFatRatio();
            bmi.Text = BMI.ToString();
            fat_ratio.Text = BFP.ToString();
        }

        private void history_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(255, 51, 51);
            Navigation.PushAsync(new WeightListHistoryPage(this.user));
        }

        private async void add_Clicked(object sender, EventArgs e)
        {
            WeightHistory wh = new WeightHistory();
            wh.UserID = this.user.UserID;
            wh.Date = DateTime.Now.ToString("dd-MM-yyyy");
            wh.BMI = double.Parse(bmi.Text);
            wh.FatRatio = double.Parse(fat_ratio.Text);
            wh.Weight = int.Parse(weight.Text);
            Database db = new Database();
            db.addWeightHistory(wh);
            db.changeWeight(wh.Weight, this.user.UserID);
            this.user.UserWeight = wh.Weight;
            await DisplayAlert("Thông báo", "Thêm thành công", "Trở lại");
            UpdateValue();
        }
    }
}