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
    public partial class WaterHistory : ContentPage
    {
        User user;
        public WaterHistory()
        {
            InitializeComponent();
        }
        public WaterHistory(User user)
        {
            InitializeComponent();
            this.user = user;
            String myDate = DateTime.Now.ToString("dd-MM-yyyy");
            date.Text = myDate;
            Database db = new Database();
            List<WaterHisory> list_wh = db.getWaterHistoryByDay(this.user.UserID, myDate);
            if(list_wh!=null)
            {
                history_list.ItemsSource = list_wh;
            }
        }
    }
}