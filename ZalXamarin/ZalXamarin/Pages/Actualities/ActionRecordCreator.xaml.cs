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
    public partial class ActionRecordCreator : ContentPage
    {
        ActionEvent action;

        public ActionRecordCreator(ActionEvent action) {
            this.action = action;
            InitializeComponent();
            Title = action.Name + " - zápis z akce";
        }

        private void AddButton_Clicked(object sender, EventArgs args) {
            Zal.Actualities.AddNewRecord(action, textEditor.Text);
            Navigation.PopAsync();
        }
    }
}