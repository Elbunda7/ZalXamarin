using DL;
using DL.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages.ProfilePropertyElements;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User CurrentUser;

        public ProfilePage(User user = null) {
            if (user == null) {
                CurrentUser = IS.Me;
            }
            else {
                CurrentUser = user;
                //LogOutButton.IsVisible = false;
            }
            InitializeComponent();
            BindingContext = CurrentUser;
            InitProfileProperties();
        }

        private void InitProfileProperties() {
            PropLayout.Children.Add(new PropertyBadges());
            PropLayout.Children.Add(new PropertyPoints());
            SetOnClickEvents();
        }

        private void SetOnClickEvents() {
            foreach (ProfilePropertyFrame profileProperty in PropLayout.Children) {
                profileProperty.OnClick += Property_Clicked;
            }
        }

        private void Property_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new EmptyPage());
        }

        private async void LogOutButton_Clicked(object sender, EventArgs args) {
            IS.Logout();
            Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }


    }
}