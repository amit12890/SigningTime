using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace SigningTime
{
    public partial class FlashCardCarousel : CarouselPage
    {
        public FlashCardCarousel(List<Sign> listOfSigns)
        {

            InitializeComponent();

            // Randomize the list of signs
            Random rnd = new Random();
            for (int i = 0; i < listOfSigns.Count; i++)
            {
                // Get random index for swapping with 'i'
                int randomIndex = rnd.Next(0, listOfSigns.Count);

                // Do the swap
                Sign randomSign = listOfSigns[randomIndex];
                listOfSigns[randomIndex] = listOfSigns[i];
                listOfSigns[i] = randomSign;
            }

            // Create a flash card page for each sign and add it to the carousel
            int numOfCards = listOfSigns.Count;
            for (int i = 0; i < numOfCards; i++)
            {
                FlashCard flashCardPage = new FlashCard(listOfSigns[i], i + 1, numOfCards);
                Children.Add(flashCardPage);
            }
        }

        /// <summary>
        /// This will pause the video of a card if the user navigates away from 
        /// the flash cards by selecting another tab while a video is playing.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((FlashCard)CurrentPage).HideVideoAfterSwipe();
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
                ((FlashCard)Children[1]).HideVideoAfterSwipe();
            }
            else if(indexOfCurrentPage == Children.Count-1){
                ((FlashCard)Children[Children.Count - 2]).HideVideoAfterSwipe();
            }
            else{
                ((FlashCard)Children[indexOfCurrentPage - 1]).HideVideoAfterSwipe();
                ((FlashCard)Children[indexOfCurrentPage + 1]).HideVideoAfterSwipe();
            }
        }

    }
}