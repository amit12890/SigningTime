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

        string internetURL = "https://ia800201.us.archive.org/12/items/BigBuckBunny_328/BigBuckBunny_512kb.mp4";

        public SignDemonstration(Sign tappedSign)
        {
            if (tappedSign == null)
            {
                throw new ArgumentNullException();
            }

            BindingContext = tappedSign;

            InitializeComponent();
        }

        // https://youtu.be/luDyX0kYzY4?t=7m40s "The file could be embedded in your project."
        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            // Xamarin.Essentials File System Helpers Documentation:
            // To get the application's directory to store cache data. Cache 
            // data can be used for any data that needs to persist longer than 
            // temporary data, but should not be data that is required to 
            // properly operate.

            using (var stream = await FileSystem.OpenAppPackageFileAsync("banana.mp4"))
            {
                // Get the location for the copy of the file
                var cacheDirectory = FileSystem.CacheDirectory;
                cacheDirectory += "/banana.mp4";

                using (Stream file = File.Create(cacheDirectory))
                {
                    // Size of the buffer to use while writing
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    // 
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                    }
                }
            }

            // Get the path to the video file
            var videoClip = FileSystem.CacheDirectory + "/banana.mp4";
            System.Diagnostics.Debug.WriteLine(videoClip); // Path to video file
            System.Diagnostics.Debug.WriteLine("Does file exist?: " + File.Exists(videoClip)); // Whether video file actually exists

            // Play the video file
            await CrossMediaManager.Current.Play("file://" + videoClip, MediaFileType.Video);

        }
    }
}