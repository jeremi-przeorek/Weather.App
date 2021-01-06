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
        private WeatherLocationRepository _weatherLocationRepository = new WeatherLocationRepository();

        private List<WeatherLocation> _locationsUnfiltered;
        private List<WeatherLocation> _locations;
        public List<WeatherLocation> Locations
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
            AddLocationCommand = new Command<WeatherLocation>(async (location) => await AddLocation(location));
        }

        public ICommand LoadLocationsCommand { get; set; }
        public ICommand AddLocationCommand { get; set; }

        private async Task LoadLocations()
        {
            Locations = new List<WeatherLocation>(await ResourcesLoader.LoadWeatherLocations());
            _locationsUnfiltered = Locations;
        }

        private void TextChangedInSearchBar(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Locations = new List<WeatherLocation>(
                    _locationsUnfiltered.Where(x => x.City.StartsWith(input, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                Locations = _locationsUnfiltered;
            }
        }

        private async Task AddLocation(WeatherLocation location)
        {
            _weatherLocationRepository.Add(new WeatherLocation
            {
                City = location.City,
                CountryCode = location.CountryCode,
            });

            await _pageService.DisplayAlert(string.Empty, string.Format("Properly added city: {0}", location.City), "Ok");
        }
    }
}
