using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SigningTime.ViewModels
{
    public class SignsViewModel : INotifyPropertyChanged
    {

        public TrulyObservableCollection<Sign> listOfSigns { get; private set; } = new TrulyObservableCollection<Sign>();

        // Through binding context, Xamarin.Forms will automatically subscribe to this.
        public event PropertyChangedEventHandler PropertyChanged;


        public SignsViewModel()
        {
            listOfSigns = new TrulyObservableCollection<Sign>
            {
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
                new Sign { Name = "grandma", Description = "Put the thumb of your open hand on your chin, just like \"mom,\" but bounce your hand forward", UseAsFlashCard = true },
                new Sign { Name = "grandpa", Description = "Put the thumb of your open hand on your forehead, just like \"dad,\" but bounce your hand forward", UseAsFlashCard = true},
                new Sign { Name = "horse", Description = "Touch your thumb to the side of your head and wave your first two fingers forward a few times, like a horse’s ear.", UseAsFlashCard = true },
                new Sign { Name = "hurt", Description = "Push your pointer fingers together over the top of your owie.", UseAsFlashCard = true }, // LONGER THAN 15sec
                new Sign { Name = "juice", Description = "Use your pinky finger to draw a \"J\" for Juice.", UseAsFlashCard = true },
                new Sign { Name = "milk", Description = "Squeeze and relax your fist a few times, like you're milking a cow.", UseAsFlashCard = true },
                new Sign { Name = "mom", Description = "Put the thumb of your open hand on your chin.", UseAsFlashCard = true },
                new Sign { Name = "more", Description = "Tap your closed fingertips together a few times.", UseAsFlashCard = true },
                new Sign { Name = "potty", Description = "Tuck your thumb between your pointer and middle fingers, and shake it a little.", UseAsFlashCard = true},
                new Sign { Name = "water", Description = "Make a \"W\" with your three fingers, and tap it at your chin a few times.", UseAsFlashCard = true },
                new Sign { Name = "where", Description = "With your pointer finger up, shake your hand from side to side, like you are not sure where to point.", UseAsFlashCard = true }
            };
        }


    }
}