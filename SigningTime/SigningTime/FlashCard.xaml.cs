using System;
using Octane.Xamarin.Forms.VideoPlayer; // For the video player
using Octane.Xamarin.Forms.VideoPlayer.Events;
using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCard : ContentPage
    {

        private Sign sign;
        private bool front; // Represents if card front is facing out
        private bool cardInVideoMode;

        // Parameterless constructor for building the layout
        public FlashCard()
        {
            InitializeComponent();
        }

        public FlashCard(Sign sign, int cardNumber, int numOfCards)
        {
            // Initialize member variables and layout
            this.sign = sign;
            front = true;
            InitializeComponent();

            // Sets up the card's Views with correct values
            currentCardNumber.Text = "(" + cardNumber + "/" + numOfCards + ")";
            signName.Text = sign.Name;
            signDescription.Text = sign.Description;
            signImage.Source = sign.Name;

            // Hide/Display the correct views for the card's front
            signName.IsVisible = false;
            signDescription.IsVisible = false;
            signImage.IsVisible = true;
            videoButton.IsVisible = false;

            // Set up the VideoPlayer object
            videoPlayer.Source = VideoSource.FromResource(sign.Name + ".mp4");
            // Registers what to do with the video player based on video state
            videoPlayer.Completed += (object sender, VideoPlayerEventArgs e) => {
                ResetAndHideVideo();
            };

            // Add the video to the layout
            outerLayout.Children.Add(videoPlayer);
            outerLayout.RaiseChild(videoPlayer);

            // Can't have a resoruce image file with name "new", so 
            // add '_' to the name for the img file
            if (sign.Name.Equals("new"))
            {
                signImage.Source = sign.Name + "_";
            }
            else
            {
                signImage.Source = sign.Name;
            }
        }

        /// <summary>
        /// Begins playing the demonstration video associated with this sign.
        /// 
        /// The FlashCards are set up with two Grids, one on top of the other. 
        /// This allows for the easy positioning of the video player right on 
        /// top of the underlying "card."
        /// 
        /// The underlying static image of the sign as well as its descriptive
        /// text is hidden from view, and the VideoPlayer is revealed. As
        /// defined in the cosntructor, the VideoPlayer will hide and the static 
        /// information will reappear once the video terminates.
        /// 
        /// </summary>
        private void DemonstrateSign(object sender, System.EventArgs e)
        {
            // Hide underlying text and static image
            signDescription.Opacity = 0.1;
            signImage.Opacity = 0.1;

            // Set up and start the video
            cardInVideoMode = true;
            videoPlayer.IsVisible = true;
            videoPlayer.Play();
        }

        /// <summary>
        /// Flips a card to the other side. Applies some animations to rotate
        /// the card half way, then populates the card with the correct data, 
        /// then finishes rotating card to create illusion of flipping.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private async void FlipCard(object sender, System.EventArgs e)
        {
            uint speed = 400;

            if(cardInVideoMode){
                videoPlayer.Pause();
            }

            // Rotates the card 90 degrees
            await outerLayout.RotateYTo(-90, speed, Easing.SpringIn);
            outerLayout.RotationY = -270;

            // Switching card to the back
            if (front)
            {
                front = false;
                signName.IsVisible = true;
                videoButton.IsVisible = true;

                if (cardInVideoMode)
                {
                    videoPlayer.IsVisible = true;
                    signDescription.Opacity = 0.1;
                    signImage.Opacity = 0.1;
                }
                else
                {
                    signDescription.IsVisible = true;
                    signDescription.Opacity = 1;
                    signImage.IsVisible = true;
                    signImage.Opacity = 1 ;
                }
            }
            // Switching card to the front
            else
            {
                front = true;
                signImage.IsVisible = true;
                signImage.Opacity = 1;
                signDescription.Opacity = 1;
                signName.IsVisible = false;
                signDescription.IsVisible = false;
                videoButton.IsVisible = false;
                videoPlayer.IsVisible = false;
            }

            // Continues rotating the card the remaining 90 degrees
            await outerLayout.RotateYTo(-360, speed, Easing.SpringOut);
            outerLayout.RotationY = 0;
        }

        /// <summary>
        /// Hides the VideoPlayer from view and resets the video source.
        /// 
        /// Video playback was having some issues where if the video completed,
        /// fired the lambda function that hides the video, then the user clicked
        /// the video display/play button again, the VideoPlayer would flicker
        /// into view and then dissapear without playing anything. Resetting 
        /// the source of the video seems to reset whatever was causing
        /// the issue to occur.
        /// </summary>
        internal void ResetAndHideVideo()
        {
            // Set video parameters
            cardInVideoMode = false;
            videoPlayer.Pause();
            videoPlayer.Source = VideoSource.FromResource(sign.Name + ".mp4");
            videoPlayer.IsVisible = false;

            // Set image/text parameters
            signImage.Opacity = 1;
            if (!front)
            {
                signDescription.Opacity = 1;
            }
        }
    }
}