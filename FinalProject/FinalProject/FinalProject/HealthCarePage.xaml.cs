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
        public HealthCarePage()
        {
            InitializeComponent();
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
    }
}