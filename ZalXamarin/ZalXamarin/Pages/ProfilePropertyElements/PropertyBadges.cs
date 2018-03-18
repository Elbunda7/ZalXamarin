using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Pages.ProfilePropertyElements
{
    public class PropertyBadges:ProfilePropertyFrame
    {
        public PropertyBadges() {
            Content = new Label() {
                Text = "Odborky",
            };
        }

        protected override void RaiseOnClick(object sender, EventArgs e) {
            base.RaiseOnClick(this, new EventArgs());
        }
    }
}
