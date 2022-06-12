using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCTQuickTour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseQuickTourPage : Popup
    {
        private bool isNavigating = false;
        public BaseQuickTourPage()
        {
            InitializeComponent();
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            Size size = new Size();
            size.Width = mainDisplayInfo.Width / mainDisplayInfo.Density;
            size.Height = mainDisplayInfo.Height / mainDisplayInfo.Density;
            Size = size;
        }

        public static readonly BindableProperty NextButtonTextProperty = BindableProperty.Create(nameof(NextButtonText), typeof(string), typeof(BaseQuickTourPage), propertyChanged: OnNextButtonTextChanged);
        public static readonly BindableProperty ActualStepProperty = BindableProperty.Create(nameof(ActualStep), typeof(int), typeof(BaseQuickTourPage), propertyChanged: OnActualStepChanged);
        public static readonly BindableProperty TotalStepsProperty = BindableProperty.Create(nameof(TotalSteps), typeof(int), typeof(BaseQuickTourPage), propertyChanged: OnTotalStepsChanged);
        public static readonly BindableProperty NextPageProperty = BindableProperty.Create(nameof(NextPage), typeof(BaseQuickTourPage), typeof(BaseQuickTourPage));
        public static readonly BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(ContentView), typeof(BaseQuickTourPage), propertyChanged: OnBodyContentChanged);

        private static void OnBodyContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).body.Content = (ContentView)newValue;
        }

        private static void OnTotalStepsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).total.Text = ((int)newValue).ToString();
        }

        private static void OnActualStepChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).actual.Text = ((int)newValue).ToString();
        }

        private static void OnNextButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).nextbtn.Text = (string)newValue;
        }

        public ContentView BodyContent
        {
            get => (ContentView)GetValue(BodyContentProperty);
            set => SetValue(BodyContentProperty, value);
        }

        public int ActualStep
        {
            get => (int)GetValue(ActualStepProperty);
            set => SetValue(ActualStepProperty, value);
        }

        public BaseQuickTourPage NextPage
        {
            get => (BaseQuickTourPage)GetValue(NextPageProperty);
            set => SetValue(NextPageProperty, value);
        }

        public int TotalSteps
        {
            get => (int)GetValue(TotalStepsProperty);
            set => SetValue(TotalStepsProperty, value);
        }

        public string NextButtonText
        {
            get => (string)GetValue(NextButtonTextProperty);
            set => SetValue(NextButtonTextProperty, value);
        }

        private async Task Next(BaseQuickTourPage page)
        {
            if (isNavigating)
            {
                return;
            }

            isNavigating = true;

            Dismiss(null);
            if (page != null)
            {
                await Application.Current.MainPage.Navigation.ShowPopupAsync(page);
            }

            isNavigating = false;
        }

        private async void NextButtonClicked(object sender, EventArgs e)
        {
            if (TotalSteps - ActualStep == 1)
            {
                nextbtn.Text = "DONE";
            }
            if (TotalSteps == ActualStep)
            {
                Dismiss(null);
            }
            else
            {
                await Next(NextPage);
            }
        }

        private void SkipButtonClicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}