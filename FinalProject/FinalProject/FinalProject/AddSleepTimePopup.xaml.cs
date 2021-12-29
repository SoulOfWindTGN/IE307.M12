using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSleepTimePopup : Popup
    {
        User user;
        public AddSleepTimePopup()
        {
            InitializeComponent();
        }
        public AddSleepTimePopup(User user)
        {
            InitializeComponent();
            this.user = user;
            date_picker.MaximumDate = DateTime.UtcNow;
            date_picker.Date = DateTime.UtcNow;
        }

        private void slider_hours_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            time.Text = "Bạn đã ngủ " + Math.Round(slider_hours.Value) + " giờ " + Math.Round(slider_minutes.Value) + " phút?";
        }

        private void slider_minutes_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            time.Text = "Bạn đã ngủ " + Math.Round(slider_hours.Value) + " giờ " + Math.Round(slider_minutes.Value) + " phút?";
        }

        private void add_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            SleepHistory result = new SleepHistory();
            result.Date = date_picker.Date.ToString("dd-MM-yyyy");
            result.UserID = this.user.UserID;
            result.Hours = (int)Math.Round(slider_hours.Value);
            result.Minutes = (int)Math.Round(slider_minutes.Value);
            db.addSleep(result);
            Dismiss(null);
        }
    }
}