using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Pages.ProfilePropertyElements
{
    public class ProfilePropertyFrame:Frame
    {
        public event EventHandler OnClick;

        public ProfilePropertyFrame() {
            //Margin = new Thickness(16, 8);
            Padding = new Thickness(10);
            GestureRecognizers.Add(new TapGestureRecognizer {
                Command = new Command(() => StartRaiseOnClick()),
            });
        }

        private void StartRaiseOnClick() {
            if (OnClick != null) {
                RaiseOnClick(this, new EventArgs());
            }
        }

        protected virtual void RaiseOnClick(object sender, EventArgs e) {
            OnClick.Invoke(sender, e);
        }
    }
}
