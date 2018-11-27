using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        /// <summary>
        /// Handles what happens when the carousel rotates to another page. 
        /// Override helps to remove any left over VideoPlayer objects from a 
        /// card if a user navigates away from it. If the user chooses to
        /// navigate back to a card on which they'd watched a video, they'll
        /// be presented with the card in its original, static-image state.
        /// </summary>
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            // The first time the first card is encountered in the card deck,
            // the number of children is limited to 0 for some reason. This
            // check helps prevent the resulting crash.
            if(Children.Count <= 1){
                return;
            }

            // Remove any VideoPlayers from previously viewed card. Don't know 
            // which way the cards were swiped, so we have to check both the 
            // left and right cards.
            int indexOfCurrentPage = this.Children.IndexOf(CurrentPage);

            if (indexOfCurrentPage == 0){
                ((FlashCard)Children[1]).removeVideoFromCard();
            }
            else if(indexOfCurrentPage == Children.Count-1){
                ((FlashCard)Children[Children.Count - 2]).removeVideoFromCard();
            }
            else{
                ((FlashCard)Children[indexOfCurrentPage - 1]).removeVideoFromCard();
                ((FlashCard)Children[indexOfCurrentPage + 1]).removeVideoFromCard();
            }
        }


    }
}