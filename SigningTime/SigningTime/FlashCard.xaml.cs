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
        async void SignDemonstration(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignDemonstration(new Sign { Name = "Eat" }));
        }

        public FlashCard()
        {
            InitializeComponent();
        }
    }
}
