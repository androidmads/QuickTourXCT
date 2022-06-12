using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCTQuickTour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuickSample_Page : ContentPage
    {
        public QuickSample_Page()
        {
            InitializeComponent();

            var quickTourLauncher = QuickTourBuilder<QuickTourStep1PopUp>
                                      .Initialize()
                                      .Next(new QuickTourStep2PopUp())
                                      .Next(new QuickTourStep3PopUp())
                                      .Build();

            ShowQuickTourCommand = new Command(async () => await quickTourLauncher.LaunchAsync());

            BindingContext = this;
        }

        public ICommand ShowQuickTourCommand { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowQuickTourCommand.Execute(null);
        }

        private void ShowQuickTourClicked(object sender, EventArgs e)
        {
            ShowQuickTourCommand.Execute(null);
        }
    }
}