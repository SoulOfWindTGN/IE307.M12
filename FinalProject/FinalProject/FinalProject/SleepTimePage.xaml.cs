using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepTimePage : ContentPage
    {
        User user;
        public SleepTimePage()
        {
            InitializeComponent();
        }
        public SleepTimePage(User user)
        {
            InitializeComponent();
            this.user = user;
            UpdateValue();
            UpdateList();
        }
        private void UpdateList()
        {
            Database db = new Database();
            List<SleepHistory> list = db.getLastTenSleep(this.user.UserID);
            sleep_history.ItemsSource = null;
            sleep_history.ItemsSource = list;
        }
        private void UpdateValue()
        {
            Database db = new Database();
            List<SleepHistory> list = db.getLastTenSleep(this.user.UserID);
            if (list.Count() == 0)
            {
                average.Text = min.Text = max.Text = last_record.Text = "Chưa có dữ liệu";
            }
            else
            {
                int min_index, max_index, max_value = 0;
                int min_value = 1000;
                int average_value = 0;
                for(int i=0;i<list.Count();i++)
                {
                    int minutes = list[i].Hours * 60 + list[i].Minutes;
                    average_value += minutes;
                    if(minutes < min_value)
                    {
                        min_value = minutes;
                        min_index = i;
                    }
                    if(minutes > max_value)
                    {
                        max_value = minutes;
                        max_index = i;
                    }
                }

                average_value /= list.Count();
                List<int> average_result = ConvertMinutesToHours(average_value);
                List<int> min_result = ConvertMinutesToHours(min_value);
                List<int> max_result = ConvertMinutesToHours(max_value);

                last_record.Text = list[list.Count() - 1].Hours.ToString() + " giờ " + list[list.Count() - 1].Minutes.ToString() + " phút";
                min.Text = min_result[0].ToString() + " giờ " + min_result[1].ToString() + " phút";
                max.Text = max_result[0].ToString() + " giờ " + max_result[1].ToString() + " phút";
                average.Text = average_result[0].ToString() + " giờ " + average_result[1].ToString() + " phút";
            }
        }
        private List<int> ConvertMinutesToHours(int minutes)
        {
            List<int> result = new List<int>();
            int Hours = minutes / 60;
            int Minutes = minutes % 60;
            result.Add(Hours);
            result.Add(Minutes);
            return result;
        }
        private void add_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddSleepTimePopup(this.user));
        }
    }
}