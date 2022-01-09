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
    public partial class WaterDashboardPage : ContentPage
    {
        User user;
        public WaterDashboardPage()
        {
            InitializeComponent();
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date.Text = myDate;
        }
        public void calculate_remain()
        {
            Database db = new Database();
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            float remain_water = this.user.UserTargetWater;
            float total_water = 0;
            List<WaterHisory> list_wh = db.getWaterHistoryByDay(this.user.UserID, myDate);
            if (list_wh != null)
            {
                for (int i = 0; i < list_wh.Count(); i++)
                {
                    total_water += list_wh[i].AmountWater;
                    remain_water -= list_wh[i].AmountWater;
                }
                if (remain_water < 0)
                    remain_water = 0;
            }
            remaining_water.Text = "Cần uống thêm " + remain_water.ToString() + " Lít nữa";
            total.Text = "Hôm nay bạn đã uống " + total_water.ToString() + " lít nước";
        }
        public void add_water(String type, float amount)
        {
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            String myHour = DateTime.Now.ToString("hh:mm tt");
            WaterHisory result = new WaterHisory();
            result.UserID = this.user.UserID;
            result.Hour = myHour;
            result.Date = myDate;
            result.AmountWater = amount;
            switch (type)
            {
                case "custom":
                    result.Image = "custom_water.png";
                    break;
                case "chemistry_glass":
                    result.Image = "chemistry_glass.png";
                    break;
                case "water_glass":
                    result.Image = "water_glass.png";
                    break;
                case "medium_bottle":
                    result.Image = "medium_bottle.png";
                    break;
                case "big_bottle":
                    result.Image = "big_bottle.png";
                    break;
            }
            Database db = new Database();
            History h = new History();
            h.UserID = this.user.UserID;
            h.ActivityName = "Uống nước";
            h.Detail = result.AmountWater.ToString();
            DateTime date = DateTime.Now;
            h.Time = date.ToString();
            db.addHistory(h);
            db.addWater(result);
        }
        public WaterDashboardPage(User user)
        {
            InitializeComponent();
            Database db = new Database();
            this.user = user;
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date.Text = myDate;
            water_target.Text = user.UserTargetWater.ToString() + " Lít";
            calculate_remain();
        }

        async void change_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Thay đổi lượng nước mục tiêu", "Nhập vào lượng nước mục tiêu (lít)", initialValue: "2", maxLength: 3, keyboard: Keyboard.Numeric);
            Database db = new Database();
            if (result != null && result != "" && float.Parse(result)>=0)
            {
                db.changeTargetWater(this.user.UserID, float.Parse(result));
                this.user.UserTargetWater = float.Parse(result);
                water_target.Text = this.user.UserTargetWater.ToString() + " Lít";
                calculate_remain();
            }
        }

        private void history_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Purple;
            Navigation.PushAsync(new WaterHistory(this.user));
        }

        private async void custom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Thêm lượng nước", "Nhập vào lượng nước muốn thêm (ml)", initialValue: "120", keyboard: Keyboard.Numeric);
            if (result != null && result != "" && float.Parse(result) > 0)
            {
                add_water("custom", float.Parse(result)/1000);
                calculate_remain();
            }
        }

        private void chemistry_glass_Clicked(object sender, EventArgs e)
        {
            float amount = (float)75 / 1000;
            add_water("chemistry_glass", amount);
            calculate_remain();
        }

        private void water_glass_Clicked(object sender, EventArgs e)
        {
            float amount = (float)200 / 1000;
            add_water("water_glass", amount);
            calculate_remain();
        }

        private void medium_bottle_Clicked(object sender, EventArgs e)
        {
            float amount = (float)350 / 1000;
            add_water("medium_bottle", amount);
            calculate_remain();
        }

        private void big_bottle_Clicked(object sender, EventArgs e)
        {
            float amount = (float)500 / 1000;
            add_water("big_bottle", amount);
            calculate_remain();
        }
    }
}