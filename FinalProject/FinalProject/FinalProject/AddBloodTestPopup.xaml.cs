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
    public partial class AddBloodTestPopup : Popup
    {
        User user;
        public AddBloodTestPopup()
        {
            InitializeComponent();
        }
        public AddBloodTestPopup(User user)
        {
            InitializeComponent();
            this.user = user;
            date_picker.MaximumDate = DateTime.UtcNow;
            date_picker.Date = DateTime.UtcNow;
        }

        private void add_Clicked(object sender, EventArgs e)
        {
            double index_num = Double.Parse(index.Text);
            if (index_num <= 0)
            {
                warning.Text = "Vui lòng nhập chỉ số lớn hơn 0";
            }
            else
            {
                BloodTestHistory result = new BloodTestHistory();
                result.UserID = this.user.UserID;
                result.Date = date_picker.Date.ToString("dd-MM-yyyy");
                result.Index = index_num;
                Database db = new Database();
                db.addBloodTest(result);
                Dismiss(null);
            }
        }
    }
}