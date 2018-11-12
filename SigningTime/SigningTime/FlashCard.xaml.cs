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

        public FlashCard(Sign sign, int cardNumber)
        {
            this.sign = sign;

            InitializeComponent();

            // Sets up the current Page with correct values
            signName.Text = sign.Name.ToUpper() + " (card: " + cardNumber + ")";
            // signDescription.Text = sign.Description;
            signImage.Source = sign.Name;
        }

        /// <summary>
        /// Launches the SignDemonstration page for this sign
        /// </summary>
        async void SignDemonstration(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignDemonstration(sign));
        }

    }
}