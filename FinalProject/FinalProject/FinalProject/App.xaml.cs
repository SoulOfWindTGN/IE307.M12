using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database db = new Database();
            db.createDatabase();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
