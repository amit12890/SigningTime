using System;

using Octane.Xamarin.Forms.VideoPlayer; // For the video player
using Octane.Xamarin.Forms.VideoPlayer.Events;
using Octane.Xamarin.Forms.VideoPlayer.Constants;
using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCard : ContentPage
    {

        private Sign sign;
        private bool front; // Represents if card front is facing out
        private VideoPlayer videoPlayer;

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

            // Sets up the current Page with correct (cleared out) values
            currentCardNumber.Text = "(" + cardNumber + "/" + numOfCards + ")";
            signName.Text = "";
            signDescription.Text = "";
            videoButton.IsVisible = false;

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
        /// Launches the SignDemonstration page for this sign
        /// </summary>
        private void SignDemonstration(object sender, System.EventArgs e)
        {
            addVideoToCard();
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

            if (videoPlayer != null)
            {
                videoPlayer.Pause();
            }

            // Rotates the card 90 degrees
            await outerLayout.RotateYTo(-90, speed, Easing.SpringIn);
            outerLayout.RotationY = -270;

            // Swaps out what's present on the card
            if (front)
            { // Currently on front, so flip to back
                front = false;

                if (videoPlayer != null)
                {
                    videoPlayer.IsVisible = true;
                    signDescription.IsVisible = false;
                    signImage.IsVisible = false;
                }

                signName.Text = sign.Name;
                signDescription.Text = sign.Description;
                videoButton.IsVisible = true;
            }
            else
            {
                front = true; // Currently on back, so flip to front
                signName.Text = "";
                signDescription.Text = "";
                videoButton.IsVisible = false;

                if (videoPlayer != null)
                {
                    videoPlayer.IsVisible = false;
                    signDescription.IsVisible = true;
                    signImage.IsVisible = true;
                }
            }

            // Continues rotating the card the remaining 90 degrees
            await outerLayout.RotateYTo(-360, speed, Easing.SpringOut);
            outerLayout.RotationY = 0;
        }

        /// <summary>
        /// Adds a video player to this flash card page. For visual clarity,
        /// the underlying static image of the sign as well as its descriptive
        /// text is hidden from view, so as to not clutter the card. The video
        /// will begin playing immediately.
        /// 
        /// The FlashCards are set up with two Grids, one on top of the other. 
        /// This allows for the easy positioning of the video player right on 
        /// top of the underlying "card." 
        /// </summary>
        private void addVideoToCard()
        {

            // Set up the VideoPlayer object
            videoPlayer = new VideoPlayer
            {
                AutoPlay = true,
                DisplayControls = false,
                Source = VideoSource.FromResource(sign.Name + ".mp4"),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = new Color(254, 247, 221)
            };

            // Registers what to do with the video player based on video state
            // videoPlayer.PlayerStateChanged += testTwo;
            videoPlayer.Completed += (object sender, VideoPlayerEventArgs e) => {
                removeVideoFromCard();
            };

            // Hide underlying views (static image of sign and descriptive text)
            signDescription.IsVisible = false;
            signImage.IsVisible = false;

            // Add the video to the layout
            outerLayout.Children.Add(videoPlayer);
            outerLayout.RaiseChild(videoPlayer);
        }


        internal void removeVideoFromCard()
        {
            if(videoPlayer == null){
                return;
            }

            // Hide underlying views (static image of sign and descriptive text)
            videoPlayer.Pause();
            videoPlayer.IsVisible = false;
            signDescription.IsVisible = true;
            signImage.IsVisible = true;
        }
    }
}