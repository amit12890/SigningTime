using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
    public partial class FlashCard : ContentPage
    {

        private Sign sign;
        private bool front; // Represents if card front is facing out

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
        private async void SignDemonstration(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignDemonstration(sign));
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

            await wholePage.RotateYTo(-90, speed, Easing.SpringIn);
            wholePage.RotationY = -270;

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

            await wholePage.RotateYTo(-360, speed, Easing.SpringOut);
            wholePage.RotationY = 0;
        }
    }
}