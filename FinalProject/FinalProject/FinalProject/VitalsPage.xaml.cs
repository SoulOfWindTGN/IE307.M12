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
    public partial class VitalsPage : ContentPage
    {
        User user;
        public VitalsPage()
        {
            InitializeComponent();
        }
        public VitalsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            Database db = new Database();
            SleepHistory result = db.getLastSleep(this.user.UserID);
            BloodTestHistory result_1 = db.getLastBloodTest(this.user.UserID);
            if(result==null)
            {
                sleep_last_record.Text = "Chưa có dữ liệu";
            }
            else
            {
                sleep_last_record.Text = result.Hours.ToString() + " giờ " + result.Minutes.ToString() + " phút";
            }
            if (result_1 == null)
            {
                blood_last_record.Text = "Chưa có dữ liệu";
            }
            else
            {
                blood_last_record.Text = result_1.Index.ToString() + " mg/dl";
            }
        }

        private void sleep_time_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(252, 186, 3);
            Navigation.PushAsync(new SleepTimePage(this.user));
        }

        private void blood_test_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(252, 186, 3);
            Navigation.PushAsync(new BloodTestPage(this.user));
        }
    }
}