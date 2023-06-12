using System;
using Android.Content;
using Android.Graphics;
using NMAP;
using NMAP.Droid;
using NMAP.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameShadowRenderer))]
namespace NMAP.Droid
{
    /// <summary>
    /// 커스텀 프레임 랜더러
    /// </summary>
    public class CustomFrameShadowRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public CustomFrameShadowRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as CustomFrame;


            if (element == null) return;

            if (element.HasShadow)
            {
                Elevation = 15.0f;
                TranslationZ = 0.0f;
                SetZ(Elevation + TranslationZ);
            }

        }
    }
}