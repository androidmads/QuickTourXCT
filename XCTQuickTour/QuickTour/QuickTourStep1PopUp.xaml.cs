using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XCTQuickTour
{
    public partial class QuickTourStep1PopUp : BaseQuickTourPage, IQuickTourLauncher
    {
        public QuickTourStep1PopUp() : base()
        {
            InitializeComponent();
        }

        public Task LaunchAsync() => Xamarin.Forms.Application.Current.MainPage.Navigation.ShowPopupAsync(this);
    }
}