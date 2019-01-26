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

            Sign[] listOfSigns = 
            {
                new Sign { Name = "baby", UseAsFlashCard = true },
                new Sign { Name = "banana", UseAsFlashCard = true },
                new Sign { Name = "bird", UseAsFlashCard = true },
                new Sign { Name = "cat", UseAsFlashCard = true },
                new Sign { Name = "cereal", UseAsFlashCard = true },
                new Sign { Name = "cracker", UseAsFlashCard = true },
                new Sign { Name = "dad", UseAsFlashCard = true},
                new Sign { Name = "diaper", UseAsFlashCard = true },
                new Sign { Name = "dog", UseAsFlashCard = true },
                new Sign { Name = "drink", UseAsFlashCard = true },
                new Sign { Name = "eat", UseAsFlashCard = true },
                new Sign { Name = "finished", UseAsFlashCard = true },
                new Sign { Name = "fish", UseAsFlashCard = true },
                new Sign { Name = "frog", UseAsFlashCard = true },
                new Sign { Name = "grandma", UseAsFlashCard = true },
                new Sign { Name = "grandpa", UseAsFlashCard = true},
                new Sign { Name = "horse", UseAsFlashCard = true },
                new Sign { Name = "hurt", UseAsFlashCard = true }, // LONGER THAN 15sec
                new Sign { Name = "juice", UseAsFlashCard = true },
                new Sign { Name = "milk", UseAsFlashCard = true },
                new Sign { Name = "mom", UseAsFlashCard = true },
                new Sign { Name = "more", UseAsFlashCard = true },
                new Sign { Name = "potty", UseAsFlashCard = true},
                new Sign { Name = "water", UseAsFlashCard = true },
                new Sign { Name = "where", UseAsFlashCard = true }
            };


            var widthOfScreen = DeviceDisplay.MainDisplayInfo.Width;

            // Adds all the signs to the grid
            for (int row = 0; row < listOfSigns.Length ; row+=3)
            {
                // Add a RowDefinition to account for the current row being created.
                //gridOfSigns.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                // Adds a full set of signs to the current row
                for (int column = 0; column < 3; column++)
                {
                    // Stop filling out this row if we're out of signs
                    if (row + column+1 > listOfSigns.Length)
                    {
                        break;
                    }

                    //var BoxView = new BoxView { BackgroundColor = Color.Green };

                    /*
                    var stackLayout = new StackLayout { 
                        BackgroundColor = Color.CornflowerBlue, 
                        Orientation = StackOrientation.Vertical, 
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                        };


                    var signName = new Label {Text = listOfSigns[row+column].Name };


                    var signImage = new Image { 
                        Source = listOfSigns[row + column].Name + "_illustration", 
                        BackgroundColor = Color.GreenYellow,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        WidthRequest = 70,
                        HeightRequest = 70,
                        Aspect = Aspect.AspectFit
                        };
                        */


                    //stackLayout.Children.Add(signImage);
                    //stackLayout.Children.Add(signName);
                    //gridOfSigns.Children.Add(BoxView, column, row);
                }
            }
        }
    }
}
