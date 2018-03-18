using DL;
using DL.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        public MembersPage() {
            InitializeComponent();
            Title = "Členové";
            MyListView.ItemsSource = IS.Users.GetAll();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item is User) {
                User currentUser = e.Item as User;
                await Navigation.PushAsync(new ProfilePage(currentUser));
                (sender as ListView).SelectedItem = null;
            }
        }
    }
}