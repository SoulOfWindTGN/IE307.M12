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
    }
}