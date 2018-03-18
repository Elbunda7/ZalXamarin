using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Content;
using ZalXamarin.Elements;

[assembly: ExportRenderer(typeof(CircleButton), typeof(ZalXamarin.Droid.Renderers.CircleButtonRenderer))]
namespace ZalXamarin.Droid.Renderers
{
    class CircleButtonRenderer : ButtonRenderer
    {
        public CircleButtonRenderer(Context context) : base(context) {
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas) {
            base.OnDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
            base.OnElementChanged(e);
        }
    }
}