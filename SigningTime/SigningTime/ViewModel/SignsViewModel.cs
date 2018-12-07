using System;
using System.Collections.ObjectModel;

namespace SigningTime.ViewModels
{
    public class SignsViewModel
    {
        public ObservableCollection<Sign> ListOfSigns { get; private set; } = new ObservableCollection<Sign>
            {
                new Sign { Name = "baby" },
                new Sign { Name = "banana" },
                new Sign { Name = "bird" },
                new Sign { Name = "cat" },
                new Sign { Name = "cereal" },
                new Sign { Name = "cracker" },
                new Sign { Name = "dad" },
                new Sign { Name = "diaper" },
                new Sign { Name = "dog" },
                new Sign { Name = "drink" },
                new Sign { Name = "eat" },
                new Sign { Name = "finished" },
                new Sign { Name = "fish" },
                new Sign { Name = "frog" },
                new Sign { Name = "grandma" },
                new Sign { Name = "grandpa" },
                new Sign { Name = "horse" },
                new Sign { Name = "hurt" }, // LONGER THAN 15sec
                new Sign { Name = "juice" },
                new Sign { Name = "milk" },
                new Sign { Name = "mom" },
                new Sign { Name = "more" },
                new Sign { Name = "potty" },
                new Sign { Name = "water" },
                new Sign { Name = "where" }
            };
    }
}
