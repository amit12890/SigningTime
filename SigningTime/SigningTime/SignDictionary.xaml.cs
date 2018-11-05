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
                new Sign { Name = "Again" },
                new Sign { Name = "Baby" },
                new Sign { Name = "Banana" },
                new Sign { Name = "Bird" },
                new Sign { Name = "Car" },
                new Sign { Name = "Cat" },
                new Sign { Name = "Cereal" },
                new Sign { Name = "Cracker" },
                new Sign { Name = "Dad" },
                new Sign { Name = "Diaper" },
                new Sign { Name = "Dog" },
                new Sign { Name = "Dream" },
                new Sign { Name = "Drink" },
                new Sign { Name = "Eat" },
                new Sign { Name = "Finished" },
                new Sign { Name = "Fish" },
                new Sign { Name = "Frog" },
                new Sign { Name = "Grandma" },
                new Sign { Name = "Grandpa" },
                new Sign { Name = "Horse" },
                new Sign { Name = "Hurt" }, // LONGESR THAN 15sec
                //new Sign { Name = "I Love You" },
                new Sign { Name = "Juice" },
                new Sign { Name = "Love" },
                //new Sign { Name = "Many" },
                new Sign { Name = "Milk" },
                new Sign { Name = "Mom" },
                new Sign { Name = "More" },
                new Sign { Name = "New" },
                //new Sign { Name = "Now" },
                new Sign { Name = "Potty" },
                //new Sign { Name = "Signing" },
                //new Sign { Name = "Special" },
                //new Sign { Name = "Spirit" },
                //new Sign { Name = "Sweet" },
                //new Sign { Name = "Talent" },
                //new Sign { Name = "Time" },
                new Sign { Name = "Water" },
                new Sign { Name = "Where" }, // TODO: NEED THIS VIDEO DOWNLOADED
            };
			
			MyListView.ItemsSource = ListOfSigns;
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

            // Each 'ContentPage' has a 'Navigation' property. This creates the new page you wish to view.
            // It pushes the SignDemonstration class/page onto the "stack" of navigable pages for the back button.
            await Navigation.PushAsync(new SignDemonstration(tappedSign));

            // Deselect Item (So it doesn't remain selected after tap)
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Implement Search Bar
        }
    }
}
