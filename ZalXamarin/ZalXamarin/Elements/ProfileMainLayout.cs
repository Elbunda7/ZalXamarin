using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Elements
{
    public class ProfileMainLayout: StackLayout
    {
        private const int HEIGHT_SIZE = 150;
        public ZalDomain.ActiveRecords.User User { get; set; }

        public ProfileMainLayout(){
            HeightRequest = HEIGHT_SIZE;
            BackgroundColor = (Color)Application.Current.Resources["Primary"];
            HorizontalOptions = LayoutOptions.Fill;
            Orientation = StackOrientation.Horizontal;
            Children.Add(CreateProfileImage());
            Children.Add(CreateInfoLayout());
        }

        private View CreateProfileImage() {
            CircleImage mainImage = new CircleImage {
                Source = "profile_boy.png",
                BorderThickness = 1,
                BorderColor = (Color)Application.Current.Resources["Primary"]
            };
            CircleImage minorImage = new CircleImage {
                Source = "profile_girl.png",
                HeightRequest = WidthRequest = 40,
                BorderThickness = 2,
                BorderColor = (Color)Application.Current.Resources["PrimaryDark"]
            };
            CircleImage minorImage2 = new CircleImage {
                Source = "profile_girl.png",
                HeightRequest = WidthRequest = 40,
                BorderThickness = 2,
                BorderColor = (Color)Application.Current.Resources["Accent"]
            };
            AbsoluteLayout imageLayout = new AbsoluteLayout() {
                HeightRequest = WidthRequest = 144,
                Margin = new Thickness(10, 0, -5, 0)
            };
            imageLayout.Children.Add(mainImage);
            imageLayout.Children.Add(minorImage, new Rectangle(1.3, 0.4, 48, 48), AbsoluteLayoutFlags.PositionProportional);
            imageLayout.Children.Add(minorImage2, new Rectangle(0.8, 0.9, 48, 48), AbsoluteLayoutFlags.PositionProportional);
            return imageLayout;
        }

        private View CreateInfoLayout() {
            StackLayout infoLayout = new StackLayout() {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Label nameLabel = new Label() {
                Text = "Jméno Příjmení",
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = (Color)Application.Current.Resources["LightTextColor"],
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center
            };
            Label ageLabel = new Label() {
                Text = "16 let",
                TextColor = (Color)Application.Current.Resources["LightTextColor"],
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center
            };
            infoLayout.Children.Add(nameLabel);
            infoLayout.Children.Add(ageLabel);
            return infoLayout;
        }
    }
}
