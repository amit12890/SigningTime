using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Reflection; // For debugging the file system

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials; // For accessing the bundled app data



/*
 * Helpful resources:
 * https://stackoverflow.com/questions/52521401/how-to-play-local-video-file-mp4-in-xamarin-plateform-windos-android-and-io
 * https://stackoverflow.com/questions/51393561/xamarin-essentials-filesystem-can-you-save-async
 * iOS file system: https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/file-system
 * .Essentials File System Helpers https://docs.microsoft.com/en-us/xamarin/essentials/file-system-helpers?context=xamarin%2Fxamarin-forms&tabs=ios
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

            // Copy the video to the cache directory for playback
            setUpVideoFile(tappedSign.Name.ToLower() + ".mp4");

            InitializeComponent();
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            // Get the path to the video file
            var videoClip = FileSystem.CacheDirectory + "/video.mp4";

            // Debugging stuff
            System.Diagnostics.Debug.WriteLine(videoClip); // Path to video file
            System.Diagnostics.Debug.WriteLine("Does file exist?: " + File.Exists(videoClip)); // Whether video file actually exists
            System.Diagnostics.Debug.WriteLine(new FileInfo(videoClip).Length); // Size of file

            // Play the video file
            await CrossMediaManager.Current.Play("file://" + videoClip, MediaFileType.Video);

        }

        /*
         * Sets up the correct video to be played by this screen. Essentially, each
         * platform has a bundled in set of resource/asset files, but they need to
         * be relocated in order to be accessed. This function copies them over
         * to the cache folder associated with each platform. This allows the 
         * CrossMediaManager to accept a direct "URL" path to the clip.
         */
        private async void setUpVideoFile(String videoFileName)
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(videoFileName))
            {
                // Get the location for the copy of the file
                var cacheDirectory = FileSystem.CacheDirectory;
                cacheDirectory += "/video.mp4";

                using (Stream file = File.Create(cacheDirectory))
                {
                    // Size of the buffer to use while writing
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}