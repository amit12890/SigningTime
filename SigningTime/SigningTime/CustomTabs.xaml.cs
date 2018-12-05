using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class CustomTabs : TabbedPage
    {
        public CustomTabs()
        {
            InitializeComponent();
        }

        void MarketingLink1(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://store.signingtime.com//Signing-Time"));
        }

        void MarketingLink2(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://store.signingtime.com/baby-signing-time"));
        }

        void MarketingLink3(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://store.signingtime.com/gift-certificates"));
        }

        void MarketingLink4(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://mysigningtime.com/shop/checkout?cart=10993&coupon=14daytrial&utm_source=banner%20ad&utm_medium=website&utm_campaign=R%26Me%20Ep%201%20Release"));
        }
    }
}