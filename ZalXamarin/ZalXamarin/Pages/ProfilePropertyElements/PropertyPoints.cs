using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Pages.ProfilePropertyElements
{
    public class PropertyPoints:ProfilePropertyFrame
    {
        public PropertyPoints() {
            Content = new Label() {
                Text = "Body: 1000",
            };
        }

        protected override void RaiseOnClick(object sender, EventArgs e) {
            base.RaiseOnClick(this, new EventArgs());
        }
    }
}
