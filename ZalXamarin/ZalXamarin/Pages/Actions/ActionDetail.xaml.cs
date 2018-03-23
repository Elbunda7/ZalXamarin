using ZalDomain;
using ZalDomain.ActiveRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages.Actualities;

namespace ZalXamarin.Pages.Actions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionDetail : ContentPage
    {
        private ActionEvent action;

        public ActionDetail(ActionEvent action) {
            this.action = action;
            InitializeComponent();
            BindingContext = action;
        }

        private void InfoButton_Clicked(object sender, EventArgs args) {
            if (action.Info == null) {
                Navigation.PushAsync(new ActionInfoCreator(action));
            }
            else {
                Navigation.PushAsync(new WebViewPage(action.Info));
            }
        }

        private void RecordButton_Clicked(object sender, EventArgs args) {
            if (action.Report == null) {
                Navigation.PushAsync(new ActionRecordCreator(action));
            }
            else {
                Navigation.PushAsync(new WebViewPage(action.Report));
            }
        }

        private async void ParticipateButton_ClickedAsync(object sender, EventArgs args) {
            bool result = await action.Participate(true);
        }

        private void ClickableImageLabel_OnClick() {
            Navigation.PushAsync(new WebViewPage(action.Report));
        }
    }
}