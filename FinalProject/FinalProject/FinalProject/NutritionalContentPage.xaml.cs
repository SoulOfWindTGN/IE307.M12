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
    public partial class NutritionalContentPage : ContentPage
    {
        public NutritionalContentPage()
        {
            InitializeComponent();
            food.SelectedIndex = 0;
        }

        private void info_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hàm lượng dinh dưỡng", "Chất dinh dưỡng hay dưỡng chất là những chất hay hợp chất hóa học có vai trò duy trì sự sống và hoạt động của cơ thể " +
                "thông qua quá trình trao đổi chất và thường được cung cấp qua đường ăn uống. Đối với con người, chất dinh dưỡng được cung cấp chính qua bữa ăn hàng ngày. " +
                "Thực phẩm cung cấp nhiều loại dưỡng chất khác nhau", "Trở lại");
        }

        private void food_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(food.SelectedIndex)
            {
                case 0:
                    weight.Text = "3000 ounces";
                    calo.Text = "189,000 k.cal";
                    protein.Text = "27,000 grams";
                    carbohydrate.Text = "0,000 grams";
                    Canxi.Text = "4,000 mg";
                    fe.Text = "2,900 mg";
                    fat.Text = "8,000 grams";
                    break;
                case 1:
                    weight.Text = "3000 ounces";
                    calo.Text = "246,000 k.cal";
                    protein.Text = "20,000 grams";
                    carbohydrate.Text = "0,000 grams";
                    Canxi.Text = "9,000 mg";
                    fe.Text = "2,100 mg";
                    fat.Text = "18,000 grams";
                    break;
                case 2:
                    weight.Text = "3000 ounces";
                    calo.Text = "196,000 k.cal";
                    protein.Text = "27,000 grams";
                    carbohydrate.Text = "0,000 grams";
                    Canxi.Text = "4,000 mg";
                    fe.Text = "0,8000 mg";
                    fat.Text = "9,000 grams";
                    break;
                case 3:
                    weight.Text = "3000 ounces";
                    calo.Text = "167,000 k.cal";
                    protein.Text = "25,000 grams";
                    carbohydrate.Text = "0,000 grams";
                    Canxi.Text = "12,000 mg";
                    fe.Text = "0,900 mg";
                    fat.Text = "7,000 grams";
                    break;
                case 4:
                    weight.Text = "1000 ounces";
                    calo.Text = "164,000 k.cal";
                    protein.Text = "7,000 grams";
                    carbohydrate.Text = "5,000 grams";
                    Canxi.Text = "24,000 mg";
                    fe.Text = "0,500 mg";
                    fat.Text = "14,000 grams";
                    break;
                case 5:
                    weight.Text = "1000 cups";
                    calo.Text = "150,000 k.cal";
                    protein.Text = "8,000 grams";
                    carbohydrate.Text = "11,000 grams";
                    Canxi.Text = "291,000 mg";
                    fe.Text = "0,100 mg";
                    fat.Text = "8,000 grams";
                    break;
                case 6:
                    weight.Text = "1000 lát";
                    calo.Text = "72,000 k.cal";
                    protein.Text = "3,000 grams";
                    carbohydrate.Text = "13,000 grams";
                    Canxi.Text = "35,000 mg";
                    fe.Text = "1,000 mg";
                    fat.Text = "1,000 grams";
                    break;
            }
        }
    }
}