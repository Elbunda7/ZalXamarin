using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalXamarin.Pages.Actions;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionTabbedPage : TabbedPage
    {
        public ActionTabbedPage() {
            InitializeComponent();
            Title = "Plán akcí";            
            Children.Add(new ActionsListPage());
            Children.Add(new ActionsListPage(DateTime.Today.Year));
        }

        private async void AddButton_Clicked(object sender, EventArgs args) {
            await Navigation.PushAsync(new ActionCreator());
        }
    }
}