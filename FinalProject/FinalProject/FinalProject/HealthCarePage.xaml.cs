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
    public partial class HealthCarePage : TabbedPage
    {
        User user;
        public HealthCarePage()
        {
            InitializeComponent();
        }
        public HealthCarePage(User user)
        {
            this.user = user;
            InitializeComponent();
            user_name.Text = user.UserFullName;
            user_birthday.Text = user.UserDateOfBirth;
            user_gender.Text = user.UserGender;
            user_weight.Text = user.UserWeight.ToString();
            user_height.Text = user.UserHeight.ToString();
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date_water.Text = myDate;
            date_heartbeat.Text = myDate;

            Database db = new Database();
            List<History> list = db.getHistory(this.user.UserID);
            list_history.ItemsSource = list;
        }

        private void BMI_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Purple;
            Navigation.PushAsync(new BMI());
        }

        private void LBM_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Green;
            Navigation.PushAsync(new LeanBodyMass());
        }

        private void calo_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(8, 204, 188);
            Navigation.PushAsync(new BasalMetabolicRatePage());
        }

        private void hydration_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(35, 81, 207);
            Navigation.PushAsync(new HydrationPage());
        }

        private void editProfile_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(35, 81, 207);
            Navigation.PushAsync(new EditProfilePage(this.user));
        }

        private void body_fat_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(214, 210, 210);
            Navigation.PushAsync(new BodyFatPage());
        }

        private void ideal_weight_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(255, 221, 28);
            Navigation.PushAsync(new IdealWeightPage());
        }

        private void ffmi_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(217, 160, 174);
            Navigation.PushAsync(new FFMIPage());
        }

        private void kcal_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(101, 47, 158);
            Navigation.PushAsync(new NutritionalContentPage());
        }

        private void add_water_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Purple;
            Navigation.PushAsync(new WaterDashboardPage(this.user));
        }

        private void add_vitals_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(252, 186, 3);
            Navigation.PushAsync(new VitalsPage(this.user));
        }

        private void add_calories_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(97, 194, 150);
            Navigation.PushAsync(new CaloriesHistoryPage(this.user));
        }

        private void add_weight_Clicked(object sender, EventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromRgb(255, 51, 51);
            Navigation.PushAsync(new WeightHistoryPage(this.user));
        }

        private void addMedicine_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MedicineDashboardPage(this.user));
        }
    }
}