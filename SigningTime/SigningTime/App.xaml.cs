using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SigningTime
{
    public partial class App : Application
    {
        // APP-WIDE GLOBAL LIST
        public static List<Sign> allSigns = new List<Sign>(){
            new Sign { Name = "baby", UseAsFlashCard = true, Description = "Pretend that you're cradling and rocking a baby." },
            new Sign { Name = "banana", UseAsFlashCard = true, Description = "Point one finger up and pretend you're peeling a banana." },
            new Sign { Name = "bird", UseAsFlashCard = true, Description = "Open and close your pointer finger a few times to make a bird's beak." },
            new Sign { Name = "cat", UseAsFlashCard = true, Description = "Brush your closed pointer finger and thum away from your cheek one or two times, like you're stroking a cat's whisker." },
            new Sign { Name = "cereal", UseAsFlashCard = true, Description = "Wiggle your bent pointer finger across your chin." },
            new Sign { Name = "cracker",UseAsFlashCard = true, Description = "Knock your fist on your elbow a few times." },
            new Sign { Name = "dad", UseAsFlashCard = true, Description = "Put the thumb of your open hand on your forehead."},
            new Sign { Name = "diaper", UseAsFlashCard = true, Description = "Tap your first two fingers against your thumbs twice, right where you fasten a diaper." },
            new Sign { Name = "dog", UseAsFlashCard = true, Description = "Pat your leg, or pat and snap like you're calling a dog." },
            new Sign { Name = "drink", UseAsFlashCard = true, Description = "Pretend to drink from a cup." },
            new Sign { Name = "eat", UseAsFlashCard = true, Description = "Tap your fingers to your mouth a few times, just like you're going to eat something. It's also the sign for food." },
            new Sign { Name = "finished", UseAsFlashCard = true, Description = "Twist your hands back and forth a few times, like you are brushing everything away. It’s also the sign for all done." },
            new Sign { Name = "fish", UseAsFlashCard = true, Description = "Wiggle your hand away from you like a fish swimming." },
            new Sign { Name = "frog", UseAsFlashCard = true, Description = "Rest your chin on your fist and flick your first two fingers out a few times, like frog legs hopping." },
            new Sign { Name = "grandma", UseAsFlashCard = true, Description = "Put the thumb of your open hand on your chin, just like \"mom,\" but bounce your hand forward"},
            new Sign { Name = "grandpa", UseAsFlashCard = true, Description = "Put the thumb of your open hand on your forehead, just like \"dad,\" but bounce your hand forward"},
            new Sign { Name = "horse", UseAsFlashCard = true, Description = "Touch your thumb to the side of your head and wave your first two fingers forward a few times, like a horse’s ear." },
            new Sign { Name = "hurt", UseAsFlashCard = true, Description = "Push your pointer fingers together over the top of your owie." }, // LONGER THAN 15sec
            new Sign { Name = "juice", UseAsFlashCard = true, Description = "Use your pinky finger to draw a \"J\" for Juice." },
            new Sign { Name = "milk", UseAsFlashCard = true, Description = "Squeeze and relax your fist a few times, like you're milking a cow." },
            new Sign { Name = "mom", UseAsFlashCard = true, Description = "Put the thumb of your open hand on your chin." },
            new Sign { Name = "more", UseAsFlashCard = true, Description = "Tap your closed fingertips together a few times." },
            new Sign { Name = "potty", UseAsFlashCard = true, Description = "Tuck your thumb between your pointer and middle fingers, and shake it a little." },
            new Sign { Name = "water", UseAsFlashCard = true, Description = "Make a \"W\" with your three fingers, and tap it at your chin a few times." },
            new Sign { Name = "where", UseAsFlashCard = true, Description = "With your pointer finger up, shake your hand from side to side, like you are not sure where to point." }
        };

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