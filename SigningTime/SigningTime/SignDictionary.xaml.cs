using SigningTime.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignDictionary : ContentPage
    {

        public SignDictionary()
        {
            BindingContext = new SignsViewModel();
            InitializeComponent();
        }

        // async keyword enables the await keyword to work. Any function using 'await' must
        // be marked with 'async'. async/wait patterns are intended to produce code whose logical
        // structure resembles synchronous code, but with the advantages of asynchronous programming
        // with a fraction of the effort. More explinations found here:
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/index
        private async void GoToSignDemonstration(object sender, ItemTappedEventArgs e)
        {
            // Get the sign that was tapped
            Sign tappedSign = e.Item as Sign;
            await Navigation.PushAsync(new SignDemonstration(tappedSign));

            // Deselect Item (So it doesn't remain selected after tap)
            ((ListView)sender).SelectedItem = null;
        }



    }
}