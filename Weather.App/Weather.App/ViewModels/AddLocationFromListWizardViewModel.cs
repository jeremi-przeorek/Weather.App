using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<WeatherLocation> _locationsUnfiltered;

        private ObservableCollection<WeatherLocation> _locations;
        public ObservableCollection<WeatherLocation> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        private string _searchBarText;
        public string SearchBarText
        {
            get { return _searchBarText; }
            set
            {
                _searchBarText = value;
                TextChangedInSearchBar(value);
            }
        }

        public AddLocationFromListWizardViewModel()
        {
            LoadLocationsCommand = new Command(async () => await LoadLocations());
        }

        public ICommand LoadLocationsCommand { get; set; }

        private async Task LoadLocations()
        {
            Locations = new ObservableCollection<WeatherLocation>(await ResourcesLoader.LoadWeatherLocations());
            _locationsUnfiltered = Locations;
        }

        private void TextChangedInSearchBar(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Locations = new ObservableCollection<WeatherLocation>(
                    _locationsUnfiltered.Where(x => x.City.StartsWith(input, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                Locations = _locationsUnfiltered;
            }
        }
    }
}
