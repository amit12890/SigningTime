using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GreetingPage : ContentPage
	{
		public GreetingPage ()
		{
			InitializeComponent ();
		}

        /// <summary>
        /// What happens when the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title of alert", "Hello World, this is the message.", "NAME OF CANCEL BUTTON");
        }
    }
}