using ZalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages.Actions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionCreator : ContentPage
    {
        public ActionCreator() {
            InitializeComponent();
        }

        private async Task AddButton_Clicked(object sender, EventArgs args) {
            string type = TypeEntry.Text ?? "";
            string name = NameEntry.Text ?? "";
            int days = DaysEntry.Text == null ? 0 : int.Parse(DaysEntry.Text);
            await Zal.Actions.AddNewActionAsync(name, type, datePicker.Date, datePicker.Date, 0, true);
            await Navigation.PopAsync();
        }
    }
}