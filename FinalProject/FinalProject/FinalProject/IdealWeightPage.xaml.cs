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
    public partial class IdealWeightPage : ContentPage
    {
        public IdealWeightPage()
        {
            InitializeComponent();
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Trọng lượng lý tưởng", "Tính toán trọng lượng cơ thể lý tưởng để kiểm tra cân nặng phù hợp nhằm ngặn chặn các nguy cơ " +
                "về sức khỏe. Ngoài ra, nó cũng được dùng trong y học với các mục đích như điều chỉnh chế độ ăn uống, điều chỉnh liều thuốc, kiểm " +
                "tra điều kiện sức khỏe trước và sau phẫu thuật, điều trị,...", "Trở lại");
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            height.Text = "";
            male.IsChecked = true;
            female.IsChecked = false;
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            int Height = Int32.Parse(height.Text);
            double OverHeight = 0.032808398950131 * Height - 5;
            double IBW;
            if (OverHeight > 0)
                OverHeight *= 12;
            else
                OverHeight = 0;
            if(male.IsChecked)
            {
                IBW = 50 + 2.3 * OverHeight;
            }
            else
            {
                IBW = 45.5 + 2.3 * OverHeight;
            }
            DisplayAlert("Trọng lượng lý tưởng", Math.Round(IBW, 2).ToString() + " Kg", "Trở lại");
        }
    }
}