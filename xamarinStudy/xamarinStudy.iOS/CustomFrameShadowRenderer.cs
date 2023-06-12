using System;
using NMAP.Droid;
using NMAP.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameShadowRenderer))]
namespace NMAP.Droid
{
    /// <summary>
    /// 커스텀 프레임 랜더러
    /// </summary>
    public class CustomFrameShadowRenderer : FrameRenderer
    {
        public CustomFrameShadowRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            return;
        }
    }
}