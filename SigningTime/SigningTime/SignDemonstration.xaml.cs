using System;
using System.IO;
using System.Threading.Tasks;

using Octane.Xamarin.Forms.VideoPlayer; // For the video player

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



/*
 * Helpful resources related to the video playback:
 * http://www.adams.life/blog/2016/03/cross-platform-video-player-xamarin-forms/
 * https://github.com/adamfisher/Xamarin.Forms.VideoPlayer/blob/master/GettingStarted.md
 * https://blog.xamarin.com/delivering-rich-media-experiences-xamarin-forms-video-player/
 */
namespace SigningTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignDemonstration : ContentPage
    {

        public SignDemonstration(Sign tappedSign)
        {
            // Make sure the Sign object
            if (tappedSign == null)
            {
                throw new ArgumentNullException();
            }

            // BindingContexts allow the object to be used within the XAML file
            BindingContext = tappedSign;

            InitializeComponent();

            // Prep the VideoPlayer with the correct video file
            videoPlayer.Source = VideoSource.FromResource(tappedSign.Name + ".mp4");

        }


        protected override void OnDisappearing()
        {
            videoPlayer.Pause();
        }

    }
}