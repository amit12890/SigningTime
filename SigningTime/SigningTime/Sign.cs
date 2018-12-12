using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SigningTime
{
    public class Sign : INotifyPropertyChanged
    {

        bool isMastered;

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Learned
        {
            get { return isMastered; }
            set 
            { 
                isMastered = value; 
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
