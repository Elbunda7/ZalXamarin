using ZalDomain;
using ZalDomain.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages.Actualities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionInfoCreator : ContentPage
    {
        ActionEvent action;

        public ActionInfoCreator(ActionEvent action) {
            this.action = action;
            InitializeComponent();
            Title = action.Name + " - informačka";
        }

        private void AddButton_Clicked(object sender, EventArgs args) {
            Zal.Actualities.AddNewInfo(action, textEditor.Text, 0, 0, 0);
            Navigation.PopAsync();
        }

    }
}