using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.App.Data;
using Weather.App.Models;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    public class AddLocationFromListWizardViewModel : BaseViewModel
    {
        private List<WeatherLocation> _locations;
        public List<WeatherLocation> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        public AddLocationFromListWizardViewModel()
        {
            LoadLocationsCommand = new Command(async () => await LoadLocations());
        }

        public ICommand LoadLocationsCommand { get; set; }

        private async Task LoadLocations()
        {
            Locations = await ResourcesLoader.LoadWeatherLocations();
        }
    }
}
