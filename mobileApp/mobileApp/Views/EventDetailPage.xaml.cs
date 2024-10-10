using mobileApp.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace mobileApp.Views
{
    /// <summary>
    /// Page to show the event details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage
    {
        public EventDetailPage()
        {
            this.InitializeComponent();
            this.BindingContext = EventDetailPageViewModel.BindingContext;
        }
    }
}