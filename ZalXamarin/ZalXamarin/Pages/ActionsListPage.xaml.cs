using ZalDomain;
using ZalDomain.ActiveRecords;
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
    public partial class ActionsListPage : ContentPage
    {

        public ActionsListPage(int? year = null) {
            InitializeComponent();
            StartInitializingItems(year);
        }

        private async void StartInitializingItems(int? year) {
            if (year.HasValue) {
                Title = year.Value.ToString();
                MyListView.ItemsSource = await Zal.Actions.GetPassedActionEventsByYear(year.Value);
            }
            else {
                Title = "Nadcházející";
                MyListView.ItemsSource = Zal.Actions.UpcomingActionEvents;
            }
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item is ActionEvent) {
                ActionEvent currentEvent = e.Item as ActionEvent;
                await Navigation.PushAsync(new ActionDetail(currentEvent));
                (sender as ListView).SelectedItem = null;
            }
        }
    }
}
