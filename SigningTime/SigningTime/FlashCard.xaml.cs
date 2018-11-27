using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Octane.Xamarin.Forms.VideoPlayer; // For the video player
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
    public partial class FlashCard : ContentPage
    {

        private Sign sign;
        private bool front; // Represents if card front is facing out
        private VideoPlayer videoPlayer;

        // Parameterless constructor for building the layout
        public FlashCard(){
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
            if(sign.Name.Equals("new")){
                signImage.Source = sign.Name + "_";
            }
            else{
                signImage.Source = sign.Name;
            }
        }

        /// <summary>
        /// Launches the SignDemonstration page for this sign
        /// </summary>
        private void SignDemonstration(object sender, System.EventArgs e)
        {
            addVideoToCard();

            // Creates a video demonstration page
            // await Navigation.PushAsync(new SignDemonstration(sign));
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

            await card.RotateYTo(-90, speed, Easing.SpringIn);
            card.RotationY = -270;

            if(front){ // Currently on front, so flip to back
                front = false;
                signName.Text = sign.Name;
                signDescription.Text = sign.Description;
                videoButton.IsVisible = true;
            }
            else{
                front = true; // Currently on back, so flip to front
                signName.Text = "";
                signDescription.Text = "";
                videoButton.IsVisible = false;
            }

            await card.RotateYTo(-360, speed, Easing.SpringOut);
            card.RotationY = 0;
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
        private void addVideoToCard(){
            // Set up the VideoPlayer object
            videoPlayer = new VideoPlayer();
            videoPlayer.AutoPlay = true;
            videoPlayer.DisplayControls = true;
            videoPlayer.Source = VideoSource.FromResource(sign.Name + ".mp4");
            videoPlayer.VerticalOptions = LayoutOptions.CenterAndExpand;

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

            outerLayout.Children.Remove(videoPlayer);

            // Hide underlying views (static image of sign and descriptive text)
            signDescription.IsVisible = true;
            signImage.IsVisible = true;
        }
    }
}