using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZalXamarin.Elements
{
    public class CircleButton : Button
    {
        private int size;
        public int Size {
            get {
                return size;
            }
            set {
                size = value;
                SetDiameter();
            }
        }

        public CircleButton() : this(40) {
        }

        public CircleButton(int diameter) : base() {
            Size = diameter;
            BackgroundColor = Color.Accent;
        }

        public CircleButton(int diameter, string imageSource) : base() {
            Size = diameter;
            BackgroundColor = Color.Accent;
            Image = imageSource;
        }

        private void SetDiameter() {
            WidthRequest = size;
            HeightRequest = size;
            BorderRadius = size / 2;            
        }
    }
}
