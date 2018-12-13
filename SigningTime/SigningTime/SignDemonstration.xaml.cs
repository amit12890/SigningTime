using Octane.Xamarin.Forms.VideoPlayer; // For the video player
using Octane.Xamarin.Forms.VideoPlayer.Constants;
using Octane.Xamarin.Forms.VideoPlayer.Events;

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

        private Sign sign;

        public SignDemonstration() { InitializeComponent(); }


        public SignDemonstration(Sign tappedSign)
        {
            // BindingContexts allow the object to be used within the XAML file
            BindingContext = tappedSign;

            InitializeComponent();

            // Prep the VideoPlayer with the correct video file
            sign = tappedSign;
            videoPlayer.Source = VideoSource.FromResource(sign.Name + ".mp4");

            // Set up pause/play icons to switch based on player state
            videoPlayer.Paused += (object sender, VideoPlayerEventArgs e) => {
                videoButton.Source = "video_play_icon";
            };
            videoPlayer.Playing
             += (object sender, VideoPlayerEventArgs e) => {
                videoButton.Source = "video_pause_icon";
            };

            // Set up the play icon to reset when video completes
            videoPlayer.Completed += (object sender, VideoPlayerEventArgs e) => {
                videoButton.Source = "video_play_icon";
            };

        }


        private void BackButton(object sender, System.EventArgs e)
        {
            videoPlayer.Pause();
            Navigation.PopAsync();
        }

        /// <summary>
        /// When the user navigates away from this page via the TabbedPage, the
        /// video will automatically pause.
        /// </summary>
        protected override void OnDisappearing()
        {
            videoPlayer.Pause();
            base.OnDisappearing();
        }

        /// <summary>
        /// Togles whether the video is playing or paused.
        /// </summary>
        private void ToggleVideoPlayback(object sender, System.EventArgs e)
        {
            if (videoPlayer.State.Equals(PlayerState.Playing)){
                videoPlayer.Pause();
            }
            else if (videoPlayer.State.Equals(PlayerState.Paused))
            {
                videoPlayer.Play();
            }
            else if (videoPlayer.State.Equals(PlayerState.Completed))
            {
                videoPlayer.Source = VideoSource.FromResource(sign.Name + ".mp4");
            }
        }

        /// <summary>
        /// Pauses the video. This is needed by other functions within the app.
        /// With the Xamarin VideoPlayer, if the app navigates away from the 
        /// video while it's playing, the app will crash. This function allows, 
        /// in particular, the TabbedPage to pause the video before it navigates
        /// away. A custom tabbed page renderer was create to handle this in 
        /// iOS. This is not an issue with Android, so no renderer has been made
        /// for Android.
        /// </summary>
        public void pauseVideo()
        {
            videoPlayer.Pause();
        }
    }
}