using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; // For debugging the file system

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


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

            // use for debugging, not in released app code!
            // Check in the Application Output to see if files are being placed there
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SigningTime.SignDemonstration)).Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res.GetType());
            }

            // Gets the path to the video file.
            string appDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string solutionPath = "SigningTime.video.cracker.mp4";
            string pathToFile = Path.Combine(appDirectory, solutionPath);

            var video = new MediaFile
            {
                Type = MediaFileType.Audio,
                Availability = ResourceAvailability.Remote,
                Url = pathToFile
            };


            // Creates new MediaFile object, adds it to the queue and starts playing
            await CrossMediaManager.Current.Play(video);
            // await CrossMediaManager.Current.Play(pathToFile, MediaFileType.Video, ResourceAvailability.Remote);
            // await CrossMediaManager.Current.Play(internetURL, MediaFileType.Video, ResourceAvailability.Remote);
        }
    }
}