using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ProfileModel = mobileApp.Models.UserProfile;

namespace mobileApp.ViewModels
{
    /// <summary>
    /// ViewModel for event detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class EventDetailPage1ViewModel : BaseViewModel
    {
        #region Fields

        private static EventDetailPage1ViewModel eventDetailViewModel;

        private ObservableCollection<ProfileModel> connnections;

        private string headerImagePath;

        private Command joinCommand;

        private Command favouriteCommand;

        private Command menuCommand;

        private Command profileSelectedCommand;

        private bool isFavourite;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="EventDetailPage1ViewModel" /> class.
        /// </summary>
        public EventDetailPage1ViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of even detail view model.
        /// </summary>
        public static EventDetailPage1ViewModel BindingContext =>
            eventDetailViewModel = PopulateData<EventDetailPage1ViewModel>("detail.json");

        /// <summary>
        /// Gets or sets the header image path.
        /// </summary>
        [DataMember(Name = "headerImagePath")]
        public string HeaderImagePath
        {
            get { return App.ImageServerPath + this.headerImagePath; }
            set { this.headerImagePath = value; }
        }

        /// <summary>
        /// Gets or sets the profile image collection.
        /// </summary>
        [DataMember(Name = "connections")]
        public ObservableCollection<ProfileModel> Connections
        {
            get
            {
                return this.connnections;
            }

            set
            {
                this.SetProperty(ref this.connnections, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is favourite or not.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.SetProperty(ref this.isFavourite, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command is executed when the join button is clicked.
        /// </summary>
        public Command JoinCommand
        {
            get
            {
                return this.joinCommand ?? (this.joinCommand = new Command(this.JoinButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command(this.MenuButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the profile item is clicked.
        /// </summary>
        public Command ProfileSelectedCommand
        {
            get
            {
                return this.profileSelectedCommand ?? (this.profileSelectedCommand = new Command(this.ProfileClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "mobileApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is EventDetailPage1ViewModel))
            {
                (obj as EventDetailPage1ViewModel).IsFavourite = (obj as EventDetailPage1ViewModel).IsFavourite ? false : true;
            }
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the join button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void JoinButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the profile is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ProfileClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
