using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SigningTime
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            // The children are the pages that will appear in tabs
            this.Children.Add(new NavigationPage(new SignDictionary()));
        }
    }
}
