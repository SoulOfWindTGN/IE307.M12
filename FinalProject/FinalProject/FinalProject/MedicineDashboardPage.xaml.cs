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
    public partial class MedicineDashboardPage : ContentPage
    {
        User user;
        public MedicineDashboardPage()
        {
            InitializeComponent();
        }

        public MedicineDashboardPage(User user)
        {
            InitializeComponent();
            this.user = user;
            Database db = new Database();
            List<Medicine> list = db.getMedicine(this.user.UserID);
            if(list!=null)
            {
                history_list.ItemsSource = list;
            }
        }

        private void add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMedicinePage(this.user));
        }
    }
}