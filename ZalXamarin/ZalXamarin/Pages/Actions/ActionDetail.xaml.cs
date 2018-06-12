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

        private async Task InfoButton_ClickedAsync(object sender, EventArgs args) {
            if (action.HasInfo) {
                await Navigation.PushAsync(new WebViewPage(await action.InfoLazyLoad()));
            }
            else {
                await Navigation.PushAsync(new ActionInfoCreator(action));
            }
        }

        private async Task RecordButton_ClickedAsync(object sender, EventArgs args) {
            if (action.HasReport) {
                await Navigation.PushAsync(new WebViewPage(await action.ReportLazyLoad()));
            }
            else {
                await Navigation.PushAsync(new ActionRecordCreator(action));
            }
        }

        private async void ParticipateButton_ClickedAsync(object sender, EventArgs args) {
            bool result = await action.Participate(true);
        }

        private async Task ClickableImageLabel_OnClickAsync() {
            await Navigation.PushAsync(new WebViewPage(await action.ReportLazyLoad()));
        }
    }
}