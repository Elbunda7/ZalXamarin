using ZalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {

        public LoginPage() {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, EventArgs args) {
            LoginUser(EmailEntry.Text, PasswordEntry.Text);
        }

        private async void LoginUser(string email, string password) {
            bool isLogged = await Zal.LoginAsync(email, password);
            if (isLogged) {
                ShowProfile();
            }
            else {
                await DisplayAlert("Přihlášení", "Přihlášení se nezdařilo", "Ok");
                ShowProfile();
            }
        }

        private async void ShowProfile() {
            Navigation.InsertPageBefore(new ProfilePage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private async void ToRegistration_Click() {
            await Navigation.PushAsync(new RegistrationPage());
            Navigation.RemovePage(this);
        }

        private void DevLoginLeader_Click(object sender, EventArgs args) {
            LoginUser("Leader@email.cz", "pass");
        }

        private void DevLoginMember_Click(object sender, EventArgs args) {
            LoginUser("Member@email.cz", "pass");
        }

        private void DevLoginNovice_Click(object sender, EventArgs args) {
            LoginUser("Novice@email.cz", "pass");
        }
    }
}