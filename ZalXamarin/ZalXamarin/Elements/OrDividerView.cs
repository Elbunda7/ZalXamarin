using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Elements
{
    public class OrDividerView:StackLayout
    {
        public OrDividerView() {
            Orientation = StackOrientation.Horizontal;
            Children.Add(CreateDivider());
            Children.Add(CreateLayout());
            Children.Add(CreateDivider());
        }

        private BoxView CreateDivider() {
            return new BoxView() {
                HeightRequest = 1,
                BackgroundColor = Color.GhostWhite,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
        }

        private Label CreateLayout() {
            return new Label() {
                Text = "nebo",
                TextColor = Color.White,
                Margin = new Thickness(10, 0),
            };
        }
    }
}
