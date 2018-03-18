using DL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages;

namespace ZalXamarin.SideMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        public event EventHandler MenuHeaderClicked;
        public ListView ListView;

        public SideMenuMaster() {
            InitializeComponent();

            BindingContext = new SideMenuMasterViewModel();
            ListView = MenuItemsListView;
            //ConnectionLabel.Text = "Online: " + IS.IsConnected;
        }
                

        class SideMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideMenuItem> MenuItems { get; set; }

            public SideMenuMasterViewModel() {
                MenuItems = new ObservableCollection<SideMenuItem>(
                new[]{
                    new SideMenuItem("Aktuality", typeof(ActualitiesPage), "ic_explore_black_24dp.png"),
                    new SideMenuItem("Plán akcí", typeof(MainPage), "ic_event_black_24dp.png"),
                    new SideMenuItem("Členové", typeof(MembersPage), "ic_people_black_24dp.png"),
                    new SideMenuItem("Galerie", typeof(GaleryPage), "ic_photo_library_black_24dp.png"),
                    new SideMenuItem("Studnice vědění", typeof(InformationPage), "ic_apps_black_24dp.png"),
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "") {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void LoginButton_Clicked(object sender, EventArgs e) {
            if (MenuHeaderClicked != null) {
                MenuHeaderClicked.Invoke(sender, e);
            }
        }
    }
}