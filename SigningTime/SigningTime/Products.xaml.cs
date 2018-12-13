using System;
using System.Collections.Generic;

using Xamarin.Forms;


// Helpful resource for figuring out how to create a link within a label of text
// https://xamarinhelp.com/hyperlink-in-xamarin-forms-label/
namespace SigningTime
{
    public partial class Products : ContentPage
    {
        public Products()
        {
            InitializeComponent();
        }

        void BabySigningTimeLink(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.signingtime.com/baby-signingtime-2/?utm_source=app&utm_medium=icon&utm_campaign=bst_dictionary"));
        }

        void SigningTimeLink(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.signingtime.com/signing-time2/?utm_source=app&utm_medium=icon&utm_campaign=bst_dictionary"));
        }

        void RachelAndMeLink(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.signingtime.com/rachel-me2/?utm_source=app&utm_medium=icon&utm_campaign=bst_dictionary"));
        }

        void TreeSchoolersLink(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.signingtime.com/tree-schoolers1/?utm_source=app&utm_medium=icon&utm_campaign=bst_dictionary"));
        }

        void MySigningTimeLink(object Sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://mysigningtime.com/"));
        }

    }
}
