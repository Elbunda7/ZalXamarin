using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages;

namespace ZalXamarin.SideMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenu : MasterDetailPage
    {
        public SideMenu() {
            InitializeComponent();
            MasterPage.MenuHeaderClicked += OnMenuHeaderClicked;
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void OnMenuHeaderClicked(object sender, EventArgs e) {
            Detail.Navigation.PushAsync(new LoginPage());
            HideMenu();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            SideMenuItem item = e.SelectedItem as SideMenuItem;
            if (item == null) return;
            if (item.IsActive) return;
            ShowTargetPage(item);
            HideMenu();
        }

        private void HideMenu() {
            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }

        private void ShowTargetPage(SideMenuItem item) {
            item.SetAsActive();
            Page page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
        }
    }
}