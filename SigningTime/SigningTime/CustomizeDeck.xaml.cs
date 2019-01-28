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

        public CustomizeDeck()
        {
            InitializeComponent();

            // Adds all the signs to the grid
            for (int row = 0; row < SignList.allSigns.Count ; row+=3)
            {

                // Adds a full set of signs to the current row
                for (int column = 0; column < 3; column++)
                {
                    // Stop filling out this row if we're out of signs
                    if (row + column+1 > SignList.allSigns.Count)
                    {
                        break;
                    }

                    // Add a RowDefinition to account for the current row being created. NOTE: I'm not sure why,
                    // but there should only need to be one of these per three signs, but this code seems
                    // to need about one row definition per sign, even though they share rows.... ¯\_(ツ)_/¯
                    gridOfSigns.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                    // Add a border/frame to the layout
                    StackLayout stackLayout = GenerateSignButton(App.allSigns[row + column].Name);

                    Frame frame = new Frame {
                        BackgroundColor = Color.FromHex("#f48d91"),
                        BorderColor = Color.FromHex("#f17982"),
                        Padding = 0,
                        HasShadow = false,
                        CornerRadius = 5,
                        Margin = 5,
                    };

                    // Set opacity based on whether card is set to be used in the deck or not
                    if (!App.allSigns[row + column].UseAsFlashCard)
                    {
                        frame.Opacity = 0.4;
                    }

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
                        for(int i = 0; i < App.allSigns.Count; i++)
                        {
                            // Find the sign
                            if (App.allSigns[i].Name.Equals(nameOfSign))
                            {
                                // Determine if the card is set to be used or not
                                if (App.allSigns[i].UseAsFlashCard)
                                {
                                    App.allSigns[i].UseAsFlashCard = false;
                                }
                                else
                                {
                                    App.allSigns[i].UseAsFlashCard = true;
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
            for(int i = 0; i < App.allSigns.Count; i++){
                if (App.allSigns[i].UseAsFlashCard)
                {
                    newList.Add(App.allSigns[i]);
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
