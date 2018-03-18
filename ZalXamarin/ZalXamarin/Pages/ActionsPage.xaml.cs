using DL;
using DL.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages.Actions;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionsPage : ContentPage
    {

        public ActionsPage() {
            InitializeComponent();
            Title = "Plán akcí";
            ICollection<ActionEvent> items = IS.Actions.GetAll();
            MyListView.ItemsSource = items;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item is ActionEvent) {
                ActionEvent currentEvent = e.Item as ActionEvent;
                await Navigation.PushAsync(new ActionDetail(currentEvent));
                (sender as ListView).SelectedItem = null;
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new ActionCreator());
        }

        private async void tapStart() {
            await DisplayAlert("Pinch", "start", "ok");
        }

        private async void tapFinish() {
            await DisplayAlert("Pinch", "finish", "ok");
        }
    }
}
