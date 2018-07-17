using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalDomain;
using ZalDomain.consts;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCreator : ContentPage
    {
        public UserCreator() {
            InitializeComponent();
        }

        private async Task AddButton_Clicked(object sender, EventArgs args) {
            string name = NameEntry.Text ?? "defaultName";
            string surname = SurnameEntry.Text ?? "defaultSurname";
            await Zal.Users.AddNewUser(name, surname, (int)ZAL.Group.Non);
            await Navigation.PopAsync();
        }
    }
}