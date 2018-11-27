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
                new Sign { Name = "again" },
                new Sign { Name = "baby", Description = "Pretend that you're cradling and rocking a baby." },
                new Sign { Name = "banana" },
                new Sign { Name = "bird", Description = "Open and close your pointer finger a few times to make a bird's beak." },
                new Sign { Name = "car" },
                new Sign { Name = "cat", Description = "Brush your closed pointer finger and thum away from your cheek one or two times, like you're stroking a cat's whisker." },
                new Sign { Name = "cereal" },
                new Sign { Name = "cracker" },
                new Sign { Name = "dad", Description = "Put the thumb of your open hand on your forehead."},
                new Sign { Name = "diaper" },
                new Sign { Name = "dog", Description = "Pat your let, or pat and snap like you're calling a dog." },
                new Sign { Name = "dream" },
                new Sign { Name = "drink" },
                new Sign { Name = "eat", Description = "Tap your fingers to your mouth a few times, just like you're going to eat something. It's also the sign for food." },
                new Sign { Name = "finished" },
                new Sign { Name = "fish" },
                new Sign { Name = "frog", Description = "Flick your first two fingers out a few times, like frog legs hopping." },
                new Sign { Name = "grandma", Description = "Put the thumb of your open hand on your chin, just like \"mom,\" but bounce your hand forward"},
                new Sign { Name = "grandpa", Description = "Put the thumb of your open hand on your forehead, just like \"dad,\" but bounce your hand forward"},
                new Sign { Name = "horse" },
                new Sign { Name = "hurt" }, // LONGER THAN 15sec
                new Sign { Name = "juice" },
                new Sign { Name = "love" },
                new Sign { Name = "milk", Description = "Squeeze and relax your fist a few times, like you're milking a cow." },
                new Sign { Name = "mom" },
                new Sign { Name = "more" },
                new Sign { Name = "new" },
                new Sign { Name = "potty", Description = "Tuck your thumb between your pointer and middle fingers, and shake it a little." },
                new Sign { Name = "water" },
                new Sign { Name = "where" }, // TODO: NEED THIS VIDEO DOWNLOADED
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
            int numOfCards = allSigns.Count;
            for (int i = 0; i < numOfCards; i++)
            {
                FlashCard flashCardPage = new FlashCard(allSigns[i], i + 1, numOfCards);
                Children.Add(flashCardPage);
            }

        }
    }
}