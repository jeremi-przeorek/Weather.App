using Weather.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocationFromListWizard : CarouselPage
    {
        public AddLocationFromListWizard()
        {
            InitializeComponent();

            BindingContext = new AddLocationFromListWizardViewModel();
        }

        protected override  void OnAppearing()
        {
            ViewModel.LoadLocationsCommand.Execute(null);

            base.OnAppearing();
        }

        private AddLocationFromListWizardViewModel ViewModel
        {
            get { return BindingContext as AddLocationFromListWizardViewModel; }
            set { BindingContext = value; }
        }
    }
}