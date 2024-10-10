using mobileApp.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace mobileApp.Views
{
    /// <summary>
    /// Page to display articles as a card type.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCardPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleCardPage" /> class.
        /// </summary>
        public ArticleCardPage()
        {
            this.InitializeComponent();
            this.BindingContext = ArticleCardPageViewModel.BindingContext;
        }
    }
}
