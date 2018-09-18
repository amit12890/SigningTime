using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SigningTime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage is a property of the base Application class (seen above).
            // And we use it to set the starting page of our application.
            // Currently set to start at the list of signs
            MainPage = new SignDictionary();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
