using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SigningTime
{
    public class Sign : INotifyPropertyChanged
    {
        bool flashCardUse;

        public string Name { get; set; }
        public string Description { get; set; }
        public bool UseAsFlashCard
        {
            get { return flashCardUse; }
            set
            {
                flashCardUse = value;
                onPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
