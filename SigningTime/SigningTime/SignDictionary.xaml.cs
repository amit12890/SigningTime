using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignDictionary : ContentPage
    {
        public ObservableCollection<Sign> ListOfSigns { get; set; }

        public SignDictionary()
        {
            InitializeComponent();

            // TODO: Add other stuff associated to the signs, particularly the videos
            // Signs that are commented out don't have a video clip for them
            ListOfSigns = new ObservableCollection<Sign>
            {
                new Sign { Name = "again" },
                new Sign { Name = "baby" },
                new Sign { Name = "banana" },
                new Sign { Name = "bird" },
                new Sign { Name = "car" },
                new Sign { Name = "cat" },
                new Sign { Name = "cereal" },
                new Sign { Name = "cracker" },
                new Sign { Name = "dad" },
                new Sign { Name = "diaper" },
                new Sign { Name = "dog" },
                new Sign { Name = "dream" },
                new Sign { Name = "drink" },
                new Sign { Name = "eat" },
                new Sign { Name = "finished" },
                new Sign { Name = "fish" },
                new Sign { Name = "frog" },
                new Sign { Name = "grandma" },
                new Sign { Name = "grandpa" },
                new Sign { Name = "horse" },
                new Sign { Name = "hurt" }, // LONGER THAN 15sec
                //new Sign { Name = "I love you" },
                new Sign { Name = "juice" },
                new Sign { Name = "love" },
                //new Sign { Name = "many" },
                new Sign { Name = "milk" },
                new Sign { Name = "mom" },
                new Sign { Name = "more" },
                new Sign { Name = "new" },
                //new Sign { Name = "now" },
                new Sign { Name = "potty" },
                //new Sign { Name = "signing" },
                //new Sign { Name = "special" },
                //new Sign { Name = "spirit" },
                //new Sign { Name = "sweet" },
                //new Sign { Name = "talent" },
                //new Sign { Name = "time" },
                new Sign { Name = "water" },
                new Sign { Name = "where" }, // TODO: NEED THIS VIDEO DOWNLOADED
            };
			
			signList.ItemsSource = ListOfSigns;
        }

        // async keyword enables the await keyword to work. Any function using 'await' must
        // be marked with 'async'. async/wait patterns are intended to produce code whose logical
        // structure resembles synchronous code, but with the advantages of asynchronous programming
        // with a fraction of the effort. More explinations found here:
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/index
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            // Get the sign that was tapped
            Sign tappedSign = e.Item as Sign;

            // Each 'ContentPage' has a 'Navigation' property. This creates the 
            // new page you wish to view. It pushes the SignDemonstration 
            // class/page onto the "stack" of navigable pages for the back 
            // button.
            await Navigation.PushAsync(new SignDemonstration(tappedSign));

            // Deselect Item (So it doesn't remain selected after tap)
            ((ListView)sender).SelectedItem = null;
        }


    }
}
