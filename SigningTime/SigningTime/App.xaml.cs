using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SigningTime
{
    public partial class App : Application
    {

        public App()
        {
            // Loads and parses the associated XAML
            InitializeComponent();

            // MainPage is a property of the base Application class. It's used 
            // to set the starting (root) page of our application.
            //
            // NavigationPage sets the page into something that can be
            // added to the navigation stack. Allows the back arrow in the 
            // Navigation Bar.
            //MainPage = new NavigationPage(new SignDictionary());

            if (Device.RuntimePlatform == (Device.iOS))
            {
                // Need custom renderer to prevent video crashes
                MainPage = new CustomTabs();
            }
            else
            {
                // No custom renderer needed for Android
                MainPage = new Tabs();
            }


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
