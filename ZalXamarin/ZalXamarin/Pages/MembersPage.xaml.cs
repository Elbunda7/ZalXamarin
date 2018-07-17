using ZalDomain;
using ZalDomain.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalDomain.Models;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        public MembersPage() {
            InitializeComponent();
            Title = "Členové";
            MyListView.ItemsSource = Zal.Users.Users.Where(x=>x.Meets(UserFilterModel.Default));

            var toolbarItem = new ToolbarItem() {
                Text = "Nový",
                Order = ToolbarItemOrder.Secondary
            };
            toolbarItem.Clicked += NewUser_ToolbarItemClicked;
            ToolbarItems.Add(toolbarItem);
        }

        private async void NewUser_ToolbarItemClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new UserCreator());
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