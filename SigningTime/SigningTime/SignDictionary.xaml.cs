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
            ListOfSigns = new ObservableCollection<Sign>
            {
                new Sign { Name = "Again" },
                new Sign { Name = "Banana" },
                new Sign { Name = "Bath" },
                new Sign { Name = "Book" },
                new Sign { Name = "Cracker" },
                new Sign { Name = "Daddy" },
                new Sign { Name = "Diaper" },
                new Sign { Name = "Eat" },
                new Sign { Name = "Finish" },
                new Sign { Name = "Hurt" },
                new Sign { Name = "Milk" },
                new Sign { Name = "Mommy" },
                new Sign { Name = "More" },
                new Sign { Name = "Outside" },
                new Sign { Name = "Please" },
                new Sign { Name = "Sorry" },
                new Sign { Name = "Play" },
                new Sign { Name = "Water" },
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
                return;

            // Get the sign that was tapped
            Sign tappedSign = e.Item as Sign;

            // Each 'ContentPage' has a 'Navigation' property. This creates the new page you wish to view.
            // It pushes the SignDemonstration class/page onto the "stack" of navigable pages for the back button.
            await Navigation.PushAsync(new SignDemonstration(tappedSign));

            //Deselect Item (So it doesn't remain selected after tap)
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Implement Search Bar
        }
    }
}
