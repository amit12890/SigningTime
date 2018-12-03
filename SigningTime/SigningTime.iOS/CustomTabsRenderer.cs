using UIKit;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SigningTime;

// Extremely helpful resource for this:
// https://forums.xamarin.com/discussion/90796/tabbedpage-event-on-tab-click-or-refresh-tab-when-same-tab-is-clicked


[assembly: ExportRenderer(typeof(CustomTabs), typeof(CustomTabsRenderer))]
namespace SigningTime
{
    public class CustomTabsRenderer : TabbedRenderer
    {

        private CustomTabs tabsPage;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                tabsPage = (CustomTabs) e.NewElement;
            }
            else
            {
                tabsPage = (CustomTabs) e.OldElement;
            }

            try
            {
                var tabbarController = (UITabBarController) this.ViewController;
                if (null != tabbarController)
                {
                    tabbarController.ViewControllerSelected += OnTabbarControllerItemSelected;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// When a user is watching a sign demonstration and clicks on the
        /// dictionary tab, the app will crash because it's trying to navigate
        /// away from a playing video. This handles that case and pauses the 
        /// video before the app transitions away from the video, allowing
        /// for a smooth transition back to the dictionary. 
        /// 
        /// Transitioning to another tab (not back to the dictionary) from a 
        /// playing video is handled by the SignDemonstration class itself.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void OnTabbarControllerItemSelected(object sender, UITabBarSelectionEventArgs eventArgs)
        {
            var currentPage = tabsPage.CurrentPage;

            // Check if the current page is a NavigationPage
            if (currentPage.GetType().Equals(typeof(NavigationPage))){

                // Go one more "current page" deep. This could be a sign demonstration
                var currentPage2 = ((NavigationPage) currentPage).CurrentPage;

                // If the second current page is a SignDemonstration, need to pause video
                if (currentPage2.GetType().Equals(typeof(SignDemonstration)))
                {
                    SignDemonstration signDemonstration = (SignDemonstration)currentPage2;
                    signDemonstration.pauseVideo();
                }
            }
        }

    }
}
