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
    public partial class ActionListViewCell : ViewCell
    {
        public ActionListViewCell() {
            InitializeComponent();
        }
    }
}