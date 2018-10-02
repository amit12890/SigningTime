using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; // For debugging the file system

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


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
        }

        // https://youtu.be/luDyX0kYzY4?t=7m40s "The file could be embedded in your project."
        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            // Gets the path to the video file.
            string pathToFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SigningTime.video.banana.mp4");

            // Creates new MediaFile object, adds it to the queue and starts playing
            await CrossMediaManager.Current.Play("file://" + pathToFile, MediaFileType.Video, ResourceAvailability.Local);
        }
    }
}