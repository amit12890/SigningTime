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
            if (tappedSign == null)
            {
                throw new ArgumentNullException();
            }

            BindingContext = tappedSign;

            InitializeComponent();

            // Prep the VideoPlayer with the correct video file
            VideoPlayer videoPlayer = this.FindByName<VideoPlayer>("video_player");
            String videoName = tappedSign.Name.ToLower() + ".mp4";
            videoPlayer.Source = VideoSource.FromResource(videoName);

            // TODO: Specify player dimensions? (use HeightRequest attribute?)
        }


        /*
         * Handles when the Play button is clicked
         */
        private void Button_ClickedAsync(object sender, EventArgs e)
        {
            // TODO: Implement custom controls
        }
    }
}