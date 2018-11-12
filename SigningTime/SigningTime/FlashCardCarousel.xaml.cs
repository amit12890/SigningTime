using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCardCarousel : CarouselPage
    {
        public FlashCardCarousel()
        {
            InitializeComponent();
        }

        async void SignDemonstration(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignDemonstration(new Sign { Name = "Eat" }));
        }
    }
}
