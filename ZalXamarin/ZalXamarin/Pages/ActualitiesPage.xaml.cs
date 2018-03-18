using DL;
using DL.ActiveRecords;
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
        public ActualitiesPage() {
            InitializeComponent();
            Title = "Novinky";
            MyListView.ItemsSource = IS.Actualities.GetAll();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item is Actuality) {
                IActualityItem item = (e.Item as Actuality).Item;
                await Navigation.PushAsync(new WebViewPage(item));
                (sender as ListView).SelectedItem = null;
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new ArticleCreator());
        }
    }
}
