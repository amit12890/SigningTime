using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class NotEnoughFlashCards : ContentPage
    {
        public NotEnoughFlashCards()
        {
            InitializeComponent();
        }

        // Return to the flash card sign selection
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        // Disable the back button press for Android
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
