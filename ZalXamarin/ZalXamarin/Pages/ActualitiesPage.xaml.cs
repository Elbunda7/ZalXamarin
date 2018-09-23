using ZalDomain;
using ZalDomain.ActiveRecords;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages.Actualities;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualitiesPage : ContentPage
    {


        int i = 0;
        public ActualitiesPage() {
            InitializeComponent();
            Title = "Novinky";
            MyListView.ItemsSource = Zal.Actualities.Data;
            Button button = new Button() {
                Text = "Load next",                
            };
            button.Clicked += Button_Clicked;
            MyListView.Footer = button;
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            await Zal.Actualities.LoadNext();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item is Article) {
                Article item = e.Item as Article;
                await Navigation.PushAsync(new WebViewPage(item));
                (sender as ListView).SelectedItem = null;
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new ArticleCreator());
        }
    }
}
