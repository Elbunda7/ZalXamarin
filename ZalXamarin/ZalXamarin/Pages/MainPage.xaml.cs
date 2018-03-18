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
    public partial class MainPage : TabbedPage
    {
        public MainPage() {
            InitializeComponent();
            Title = "Hlavní stránka";            
            Children.Add(new ActualitiesPage());
            Children.Add(new ActionsPage());            
        }
    }
}