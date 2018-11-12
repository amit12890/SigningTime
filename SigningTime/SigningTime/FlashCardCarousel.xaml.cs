using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCardCarousel : CarouselPage
    {
        public FlashCardCarousel()
        {

            // The list of signs
            List<Sign> allSigns = new List<Sign>(){
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
                new Sign { Name = "Hurt" }, // LONGER THAN 15sec
                new Sign { Name = "Juice" },
                new Sign { Name = "Love" },
                new Sign { Name = "Milk" },
                new Sign { Name = "Mom" },
                new Sign { Name = "More" },
                new Sign { Name = "New" },
                new Sign { Name = "Potty" },
                new Sign { Name = "Water" },
                new Sign { Name = "Where" }, // TODO: NEED THIS VIDEO DOWNLOADED
            };

            InitializeComponent();

            // Randomize the list of signs
            Random rnd = new Random();
            for (int i = 0; i < allSigns.Count; i++)
            {
                // Get random index for swapping with 'i'
                int randomIndex = rnd.Next(0, allSigns.Count);

                // Do the swap
                Sign randomSign = allSigns[randomIndex];
                allSigns[randomIndex] = allSigns[i];
                allSigns[i] = randomSign;
            }

            // Create a flash card page for each sign and add it to the carousel
            for (int i = 0; i < allSigns.Count; i++)
            {
                FlashCard flashCardPage = new FlashCard(allSigns[i], i+1);
                Children.Add(flashCardPage);
            }

        }
    }
}
