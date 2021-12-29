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
    public partial class BloodTestPage : ContentPage
    {
        User user;
        public BloodTestPage()
        {
            InitializeComponent();
        }
        public BloodTestPage(User user)
        {
            InitializeComponent();
            this.user = user;
            UpdateValue();
            UpdateList();
        }
        private void UpdateValue()
        {
            Database db = new Database();
            List<BloodTestHistory> list = db.getLastTenBloodTest(this.user.UserID);
            if (list.Count() == 0)
            {
                average.Text = min.Text = max.Text = last_record.Text = "Chưa có dữ liệu";
            }
            else
            {
                int min_index, max_index = 0;
                double max_value = 0;
                double average_value = 0;
                double min_value = 1000000;
                for (int i = 0; i < list.Count(); i++)
                {
                    double index_num = list[i].Index;
                    average_value += index_num;
                    if (index_num < min_value)
                    {
                        min_value = index_num;
                        min_index = i;
                    }
                    if (index_num > max_value)
                    {
                        max_value = index_num;
                        max_index = i;
                    }
                }
                average_value /= list.Count();

                last_record.Text = Math.Round(list[list.Count() - 1].Index,3).ToString() + " mg/dl";
                average.Text = Math.Round(average_value, 3).ToString() + " mg/dl";
                min.Text = Math.Round(min_value, 3).ToString() + " mg/dl";
                max.Text = Math.Round(max_value, 3).ToString() + " mg/dl";
            }
        }
        private void UpdateList()
        {
            Database db = new Database();
            List<BloodTestHistory> list = db.getLastTenBloodTest(this.user.UserID);
            blood_test_history.ItemsSource = null;
            blood_test_history.ItemsSource = list;
        }

        private void add_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddBloodTestPopup(this.user));
        }
    }
}