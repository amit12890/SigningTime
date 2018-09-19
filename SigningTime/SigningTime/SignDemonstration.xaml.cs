using Plugin.MediaManager;
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
    public partial class SignDemonstration : ContentPage
    {
        public SignDemonstration(Sign tappedSign)
        {
            if (tappedSign == null)
            {
                throw new ArgumentNullException();
            }

            BindingContext = tappedSign;

            InitializeComponent();

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossMediaManager.Current.Play("C:\\Users\\dougg\\source\repos\\SigningTime\\SigningTime\\SigningTime\video\again.mp4", Plugin.MediaManager.Abstractions.Enums.MediaFileType.Video);
        }
    }
}