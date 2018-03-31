using ZalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages.Actualities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCreator : ContentPage
    {

        public ArticleCreator() {
            InitializeComponent();
            Title = "Nový článek";
        }

        private async Task AddButton_Clicked(object sender, EventArgs args) {
            await Zal.Actualities.AddNewArticle("Title", textEditor.Text, 0);
            await Navigation.PopAsync();
        }
    }
}