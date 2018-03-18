using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Elements
{
    public class RoundedButton:Frame
    {
        public event Action OnClick;

        private Button button;
        private double diameter = 56;
        private bool isCircle = true;
        private const double  MARGIN_OFFSET = -6;

        public string Icon {
            get { return GetValue(IconProperty) as string; }
            set { SetValue(IconProperty, value); }
        }

        public string Text {
            get { return GetValue(TitleProperty) as string; }
            set { SetValue(TitleProperty, value); }
        }

        public double Diameter {
            get { return (double)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }

        public new Color BackgroundColor {
            get { return button.BackgroundColor; }
            set { button.BackgroundColor = value; }
        }

        public bool IsCircle {
            get { return (bool)GetValue(IsCircleProperty); }
            set { SetValue(IsCircleProperty, value); }
        }


        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(RoundedButton), "", BindingMode.TwoWay, null,
                new BindableProperty.BindingPropertyChangedDelegate(IconChanged));

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Text", typeof(string), typeof(RoundedButton), "", BindingMode.TwoWay, null,
                new BindableProperty.BindingPropertyChangedDelegate(TextChanged));

        public static readonly BindableProperty DiameterProperty =
            BindableProperty.Create("Diameter", typeof(double), typeof(RoundedButton), 56.0, BindingMode.TwoWay, null,
                new BindableProperty.BindingPropertyChangedDelegate(DiameterChanged));

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create("BackgroundColor", typeof(Color), typeof(RoundedButton), Color.Accent, BindingMode.TwoWay, null,
                new BindableProperty.BindingPropertyChangedDelegate(BackgroundColorChanged));

        public static readonly BindableProperty IsCircleProperty =
            BindableProperty.Create("IsCircle", typeof(bool), typeof(RoundedButton), true, BindingMode.TwoWay, null,
                new BindableProperty.BindingPropertyChangedDelegate(IsCircleChanged));

        private static void IconChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as RoundedButton).button.Image = newValue as string;
        }

        private static void TextChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as RoundedButton).button.Text = newValue as string;
        }

        private static void DiameterChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as RoundedButton).diameter = (double)newValue;
            (bindable as RoundedButton).OnDimensionsChanged();
        }

        private static void BackgroundColorChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as RoundedButton).button.BackgroundColor = (Color)newValue;
        }

        private static void IsCircleChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as RoundedButton).isCircle = (bool)newValue;
            (bindable as RoundedButton).OnDimensionsChanged();
        }

        public RoundedButton() {
            Padding = new Thickness(0);
            button = new Button {
                BackgroundColor = Color.Accent,
                Margin = new Thickness(MARGIN_OFFSET),
            };
            button.Clicked += Button_Clicked;
            Content = button;
            HorizontalOptions = LayoutOptions.Center;
            OnDimensionsChanged();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            if (OnClick != null) {
                OnClick.Invoke();
            }
        }

        private void OnDimensionsChanged() {
            if (isCircle) {
                WidthRequest = diameter;
            }
            else {
                WidthRequest = -1;
            }
            HeightRequest  = diameter;
            CornerRadius = (float)diameter / 2;
        }
    }
}
