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

        /*
        * Launches into the slide deck for the flash cards
        */
        private async void StartSlides(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage (new FlashCard()));
        }
    }
}
