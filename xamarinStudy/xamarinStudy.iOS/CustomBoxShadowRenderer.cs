using System.Drawing;
using NMAP.Utils;
using NMAP.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxShadowRenderer))]
namespace NMAP.iOS
{
    /// <summary>
    /// Ŀ���� �ڽ� ������
    /// </summary>
    public class CustomBoxShadowRenderer : BoxRenderer
    {
        public CustomBoxShadowRenderer()
        {
        }

        //this works fine on Forms nuger 4.3
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.BoxView> e)
        {
            base.OnElementChanged(e);
            var elem = (CustomBoxView)this.Element;
            if (elem != null)
            {

                // Border
                //this.Layer.CornerRadius = 10;
                //this.Layer.Bounds.Inset((int)elem.BorderThickness, (int)elem.BorderThickness);
                //Layer.BorderColor = elem.BorderColor.ToCGColor();
                //Layer.BorderWidth = (float)elem.BorderThickness;

                // Shadow
                this.Layer.ShadowColor = UIColor.DarkGray.CGColor;//UIColor.FromRGB(243, 243, 243).CGColor; //Xamarin.Forms.Color.FromHex("#f3f3f3").ToCGColor(); //Color.FromHex("#00FF00").ToUIColor();// FromHexString("#f3f3f3").CGColor;// UIColor.FromRGB(243,243,243).CGColor; //#f3f3f3 UIColor.DarkGray.CGColor;
                this.Layer.ShadowOpacity = 0.2f;
                this.Layer.ShadowRadius = 8.0f;
                this.Layer.ShadowOffset = new SizeF(0, 5);
                //this.Layer.MasksToBounds = true;

            }
        }
    }
}