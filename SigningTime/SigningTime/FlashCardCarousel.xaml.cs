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
                new Sign { Name = "Baby", Description = "Pretend that you're cradling and rocking a baby." },
                new Sign { Name = "Banana" },
                new Sign { Name = "Bird", Description = "Open and close your pointer finger a few times to make a bird's beak." },
                new Sign { Name = "Car" },
                new Sign { Name = "Cat", Description = "Brush your closed pointer finger and thum away from your cheek one or two times, like you're stroking a cat's whisker." },
                new Sign { Name = "Cereal" },
                new Sign { Name = "Cracker" },
                new Sign { Name = "Dad", Description = "Put the thumb of your open hand on your forehead."},
                new Sign { Name = "Diaper" },
                new Sign { Name = "Dog" },
                new Sign { Name = "Dream" },
                new Sign { Name = "Drink" },
                new Sign { Name = "Eat", Description = "Tap your fingers to your mouth a few times, just like you're going to eat something. It's also the sign for food." },
                new Sign { Name = "Finished" },
                new Sign { Name = "Fish" },
                new Sign { Name = "Frog" },
                new Sign { Name = "Grandma" },
                new Sign { Name = "Grandpa", Description = "Put the thumb of your open hand on your forehead, just like \"dad,\" but bounce your hand forward"},
                new Sign { Name = "Horse" },
                new Sign { Name = "Hurt" }, // LONGER THAN 15sec
                new Sign { Name = "Juice" },
                new Sign { Name = "Love" },
                new Sign { Name = "Milk", Description = "Squeeze and relax your fist a few times, like you're milking a cow." },
                new Sign { Name = "Mom" },
                new Sign { Name = "More" },
                new Sign { Name = "New" },
                new Sign { Name = "Potty", Description = "Tuck your thumb between your pointer and middle fingers, and shake it a little." },
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
                FlashCard flashCardPage = new FlashCard(allSigns[i], i + 1);
                Children.Add(flashCardPage);
            }

        }
    }
}