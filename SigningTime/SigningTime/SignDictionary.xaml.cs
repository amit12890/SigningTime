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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            // Get the sign that was tapped
            Sign currentSign = e.Item as Sign;

            // Display a simple notification stating which sign was tapped
            await DisplayAlert("Item Tapped", "You tapped " + currentSign.Name, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Implement Search Bar
        }
    }
}
