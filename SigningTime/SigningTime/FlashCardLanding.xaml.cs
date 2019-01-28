using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCardLanding : ContentPage
    {


        public FlashCardLanding()
        {
            InitializeComponent();
        }

        // Take user to the full stack of flash cards
        private async void StartFullDeck(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FlashCardCarousel(App.allSigns));
        }

        // Takes user to Page for deck customization
        private async void CustomizeDeck(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CustomizeDeck());
        }
    }
}
