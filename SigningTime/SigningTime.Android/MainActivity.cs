using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.MediaManager.Forms.Android; // For video playback
using Octane.Xamarin.Forms.VideoPlayer.Android;

namespace SigningTime.Droid
{
    [Activity(Label = "SigningTime", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // NOW DEPRECATED BECAUSE IT'S A PIECE OF CRAP
            // This will initialize the Video View Renderer. Instructions found here:
            // https://www.youtube.com/watch?v=luDyX0kYzY4&t=133s
            // VideoViewRenderer.Init();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // New video system
            FormsVideoPlayer.Init();

            LoadApplication(new App());
        }
    }
}