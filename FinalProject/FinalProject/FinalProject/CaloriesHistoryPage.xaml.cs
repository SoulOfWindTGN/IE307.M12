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
    public partial class CaloriesHistoryPage : ContentPage
    {
        User user;
        private void UpdateValue()
        {
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date.Text = "Ngày " + myDate;
            target.Text = "Mục tiêu " + this.user.UserTargetCalories + " K.cal mỗi ngày";
            Database db = new Database();
            List<CaloriesHistory> list = db.getCaloriesHistoryByDay(this.user.UserID, myDate);
            int total = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                total += list[i].calories;
            }
            current_calories.Text = total.ToString() + " / " + this.user.UserTargetCalories + " K.cal";
            if (this.user.UserTargetCalories == 0)
            {
                progress.Progress = 1;
            }
            else
            {
                progress.Progress = (double)total / this.user.UserTargetCalories;
            }
            list_calo.ItemsSource = null;
            list_calo.ItemsSource = list;
        }
        public CaloriesHistoryPage()
        {
            InitializeComponent();
        }
        public CaloriesHistoryPage(User user)
        {
            InitializeComponent();
            this.user = user;
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            UpdateValue();
        }

        private async void edit_target_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Thay đổi mục tiêu", "Nhập lượng calories mục tiêu", initialValue: "2000", keyboard: Keyboard.Numeric);
            if (result != null && double.Parse(result) > 0)
            {
                int target = (int)Math.Round(double.Parse(result));
                this.user.UserTargetCalories = target;
                Database db = new Database();
                db.changeTargetCalories(this.user.UserID, target);
                UpdateValue();
            }
        }

        private async void add_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Chọn bữa ăn", "Cancel", null, "Bữa sáng", "Bữa trưa", "Bữa ăn nhẹ", "Bữa tối");
            if(action != "Cancel" && action != null)
            {
                string result =  await DisplayPromptAsync("Calories", "Nhập lượng calories ước tính", initialValue: "800", keyboard: Keyboard.Numeric);
                if(result != null && double.Parse(result) > 0)
                {
                    CaloriesHistory calories_history = new CaloriesHistory();
                    calories_history.userID = this.user.UserID;
                    calories_history.meal = action;
                    calories_history.calories = (int)Math.Round(double.Parse(result));
                    switch (action)
                    {
                        case "Bữa sáng":
                            calories_history.image_meal = "breakfast_1.png";
                            break;
                        case "Bữa trưa":
                            calories_history.image_meal = "meal.png";
                            break;
                        case "Bữa tối":
                            calories_history.image_meal = "dinner_1.png";
                            break;
                        case "Bữa ăn nhẹ":
                            calories_history.image_meal = "snack.png";
                            break;
                    }
                    calories_history.date = DateTime.Now.ToString("dd-MM-yyyy");
                    Database db = new Database();
                    db.addCaloriesHistory(calories_history);
                    UpdateValue();
                }
            }
        }
    }
}