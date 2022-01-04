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
    public partial class WeightListHistoryPage : ContentPage
    {
        User user;
        public WeightListHistoryPage()
        {
            InitializeComponent();
        }
        public WeightListHistoryPage(User user)
        {
            InitializeComponent();
            this.user = user;
            Database db = new Database();
            lst.ItemsSource = db.getLastTenWeight(this.user.UserID);

        }
    }
}