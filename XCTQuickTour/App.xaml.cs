using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCTQuickTour
{
    public partial class App : Application
    {
        public static double h = 0, w = 0;
        public App()
        {
            InitializeComponent();

            // XCT Series Sample 1: Xamarin Community Toolkit - Featured Views
            //MainPage = new MainPage();

            // XCT Series Sample 2: Master Details Page using XCT
            //MainPage = new SideMenuPage();

            // XCT Series Sample 3: Effects using XCT
            //MainPage = new EffectsSamplePage();

            // XCT Series Sample 4: Behaviours using XCT
            //MainPage = new BehavioursSample();

            // XCT Series Sample 5: State Layout using XCT
            //MainPage = new StateLayoutSamplePage();

            // XCT Series Sample 6: Quick Tour using XCT
            MainPage = new NavigationPage(new QuickSample_Page());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
