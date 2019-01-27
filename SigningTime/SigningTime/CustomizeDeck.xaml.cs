using System;
using System.Collections;
using System.Collections.Generic;
using SigningTime.ViewModels;
using Xamarin.Essentials;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class CustomizeDeck : ContentPage
    {
        // The list of signs
        List<Sign> listOfSigns = new List<Sign>(){
            new Sign { Name = "baby", Description = "Pretend that you're cradling and rocking a baby.", UseAsFlashCard = true },
            new Sign { Name = "banana", Description = "Point one finger up and pretend you're peeling a banana.", UseAsFlashCard = true },
            new Sign { Name = "bird", Description = "Open and close your pointer finger a few times to make a bird's beak.", UseAsFlashCard = true },
            new Sign { Name = "cat", Description = "Brush your closed pointer finger and thum away from your cheek one or two times, like you're stroking a cat's whisker.", UseAsFlashCard = true },
            new Sign { Name = "cereal", Description = "Wiggle your bent pointer finger across your chin.", UseAsFlashCard = true },
            new Sign { Name = "cracker", Description = "Knock your fist on your elbow a few times.", UseAsFlashCard = true },
            new Sign { Name = "dad", Description = "Put the thumb of your open hand on your forehead.", UseAsFlashCard = true},
            new Sign { Name = "diaper", Description = "Tap your first two fingers against your thumbs twice, right where you fasten a diaper.", UseAsFlashCard = true },
            new Sign { Name = "dog", Description = "Pat your leg, or pat and snap like you're calling a dog.", UseAsFlashCard = true },
            new Sign { Name = "drink", Description = "Pretend to drink from a cup.", UseAsFlashCard = true },
            new Sign { Name = "eat", Description = "Tap your fingers to your mouth a few times, just like you're going to eat something. It's also the sign for food.", UseAsFlashCard = true },
            new Sign { Name = "finished", Description = "Twist your hands back and forth a few times, like you are brushing everything away. It’s also the sign for all done.", UseAsFlashCard = true },
            new Sign { Name = "fish", Description = "Wiggle your hand away from you like a fish swimming.", UseAsFlashCard = true },
            new Sign { Name = "frog", Description = "Rest your chin on your fist and flick your first two fingers out a few times, like frog legs hopping.", UseAsFlashCard = true },
            new Sign { Name = "grandma", Description = "Put the thumb of your open hand on your chin, just like \"mom,\" but bounce your hand forward", UseAsFlashCard = true},
            new Sign { Name = "grandpa", Description = "Put the thumb of your open hand on your forehead, just like \"dad,\" but bounce your hand forward", UseAsFlashCard = true},
            new Sign { Name = "horse", Description = "Touch your thumb to the side of your head and wave your first two fingers forward a few times, like a horse’s ear.", UseAsFlashCard = true },
            new Sign { Name = "hurt", Description = "Push your pointer fingers together over the top of your owie.", UseAsFlashCard = true }, // LONGER THAN 15sec
            new Sign { Name = "juice", Description = "Use your pinky finger to draw a \"J\" for Juice.", UseAsFlashCard = true },
            new Sign { Name = "milk", Description = "Squeeze and relax your fist a few times, like you're milking a cow.", UseAsFlashCard = true },
            new Sign { Name = "mom", Description = "Put the thumb of your open hand on your chin.", UseAsFlashCard = true },
            new Sign { Name = "more", Description = "Tap your closed fingertips together a few times.", UseAsFlashCard = true },
            new Sign { Name = "potty", Description = "Tuck your thumb between your pointer and middle fingers, and shake it a little.", UseAsFlashCard = true },
            new Sign { Name = "water", Description = "Make a \"W\" with your three fingers, and tap it at your chin a few times.", UseAsFlashCard = true },
            new Sign { Name = "where", Description = "With your pointer finger up, shake your hand from side to side, like you are not sure where to point.", UseAsFlashCard = true }
        };


        public CustomizeDeck()
        {
            InitializeComponent();

            // Adds all the signs to the grid
            for (int row = 0; row < listOfSigns.Count ; row+=3)
            {

                // Adds a full set of signs to the current row
                for (int column = 0; column < 3; column++)
                {
                    // Stop filling out this row if we're out of signs
                    if (row + column+1 > listOfSigns.Count)
                    {
                        break;
                    }

                    // Add a RowDefinition to account for the current row being created. NOTE: I'm not sure why,
                    // but there should only need to be one of these per three signs, but this code seems
                    // to need about one row definition per sign, even though they share rows.... ¯\_(ツ)_/¯
                    gridOfSigns.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                    // Add a border/frame to the layout
                    StackLayout stackLayout = GenerateSignButton(listOfSigns[row + column].Name);

                    Frame frame = new Frame {
                        BackgroundColor = Color.FromHex("#f48d91"),
                        BorderColor = Color.FromHex("f17982"),
                        Padding = 0,
                        HasShadow = false,
                        CornerRadius = 5,
                        Margin = 5,
                    };

                    // Create a gesture recognizer for when a user selects a sign
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        Frame fr = (Frame) s;
                        StackLayout sl = (StackLayout) fr.Content;
                        IList<View> stackLayoutChildren = sl.Children;
                        Label signLabel = (Label) stackLayoutChildren[1];
                        String nameOfSign = signLabel.Text;

                        // Edit the sign's "UseAsFlashcard" parameter in the array of signs
                        for(int i = 0; i < listOfSigns.Count; i++)
                        {
                            // Find the sign
                            Sign currentSign = listOfSigns[i];
                            if (currentSign.Name.Equals(nameOfSign))
                            {
                                // Determine if the card is set to be used or not
                                if (currentSign.UseAsFlashCard)
                                {
                                    currentSign.UseAsFlashCard = false;
                                }
                                else
                                {
                                    currentSign.UseAsFlashCard = true;
                                }
                                // End the for loop
                                break;
                            }
                        }

                        // Adjust the opacity of the button based on selection
                        if(fr.Opacity < 1)
                        {
                            fr.Opacity = 1;
                        }
                        else
                        {
                            fr.Opacity = 0.4;
                        }

                    }; // END GESTURE FUNCTION

                    frame.GestureRecognizers.Add(tapGestureRecognizer);
                    frame.Content = stackLayout;
                    gridOfSigns.Children.Add(frame, column, row);
                }
            }
        }


        private StackLayout GenerateSignButton(String nameOfSign)
        {

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 10
            };


            Label signLabel = new Label
            {
                TextColor = Color.FromHex("#EEEEEE"),
                Text = nameOfSign,
                FontFamily = Device.RuntimePlatform == Device.iOS ? "FredokaOne-Regular" : null, // set font for iOS
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // double screenWidth = DeviceDisplay.MainDisplayInfo.Width;

            Image signImage = new Image
            {
                Source = nameOfSign + "_illustration",
                WidthRequest = 70,
                HeightRequest = 70,
                Aspect = Aspect.AspectFit
            };


            stackLayout.Children.Add(signImage);
            stackLayout.Children.Add(signLabel);
            return stackLayout;
        }

        // Launches the carousel with the flash cards. If the user doesn't
        // have enough cards for a flash card deck, then a popup message
        // appears informing them that they need to select more cards.
        private async void StartCards(object sender, System.EventArgs e)
        {
            // Copy the selected signs into a list for the carousel
            List<Sign> newList = new List<Sign>();
            for(int i = 0; i < listOfSigns.Count; i++){
                if (listOfSigns[i].UseAsFlashCard)
                {
                    newList.Add(listOfSigns[i]);
                }
            }

            // If the user doesn't have enough cards selected, stop them
            if(newList.Count < 4)
            {
                await Navigation.PushModalAsync(new NotEnoughFlashCards());
            }
            // They have enough cards, so start the deck
            else
            {
                await Navigation.PushAsync(new FlashCardCarousel(newList));
            }

           
        }

        // Returns user back tot he Flash Card Landing Page
        private void GoBack(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }

}
