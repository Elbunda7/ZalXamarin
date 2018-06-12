using ZalDomain;
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
using ZalDomain.ActiveRecords;

namespace ZalXamarin.SideMenu
{
    public delegate void MenuActionDelegate(Page page);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        public event MenuActionDelegate MenuButtonClicked;
        public ListView ListView;

        public SideMenuMaster() {
            InitializeComponent();

            BindingContext = new SideMenuMasterViewModel();
            ListView = MenuItemsListView;

            ShowUserInTheMenu(Zal.UserIsLogged, Zal.Session.CurrentUser);
            Zal.Session.UsersSessionStateChanged += OnUsersSessionStateChanged;
        }

        private void OnUsersSessionStateChanged(Session session) {
            ShowUserInTheMenu(session.IsLogged, session.CurrentUser);
        }

        private void ShowUserInTheMenu(bool toShow, User currentUser = null) {
            LoginButton.IsVisible = !toShow;
            LogoutButton.IsVisible = toShow;
            ProfileImage.IsVisible = toShow;//todo: show user´s image
            if (toShow) {
                NameLabel.Text = currentUser.Nick;
            }
            else {
                NameLabel.Text = "TOM Zálesák";
            }
        }

        class SideMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideMenuItem> MenuItems { get; set; }

            public SideMenuMasterViewModel() {
                MenuItems = new ObservableCollection<SideMenuItem>(
                new[]{
                    new SideMenuItem("Aktuality", typeof(ActualitiesPage), "ic_explore_black_24dp.png"),
                    new SideMenuItem("Plán akcí", typeof(ActionTabbedPage), "ic_event_black_24dp.png"),
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

        private void LoginButton_Clicked(object sender, EventArgs e) => RaiseAction(new LoginPage());

        private void ProfileImage_Tapped(object sender, EventArgs e) => RaiseAction(new ProfilePage());

        private void LogoutButton_Clicked(object sender, EventArgs e) { }// => RaiseAction(sender, e);

        private void RaiseAction(Page page) {
            if (MenuButtonClicked != null) {
                MenuButtonClicked.Invoke(page);
            }
        }
    }
}