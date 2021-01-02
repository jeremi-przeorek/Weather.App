using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Weather.App.Models;
using Weather.App.Services;
using Weather.App.Views;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    class GeneralListViewModel : BaseViewModel
    {
        private WeatherLocationRepository _weatherLocationRepository = new WeatherLocationRepository();

        public GeneralListViewModel()
        {
            _pageService = new PageService();
            WeatherLocations = new ObservableCollection<WeatherLocation>(_weatherLocationRepository.GetAll());
            ShowAddLocationWizardCommand = new Command(ShowAddLocationWizard);
            UpdateWeatherLocationsListCommand = new Command(UpdateWeatherLocationsList);
            ShowWeatherPresentationPageCommand = new Command<WeatherLocation>(ShowWeatherPresentationPage);
        }

        public List<WeatherLocation> Locations { get; set; } = new List<WeatherLocation>
        {
            new WeatherLocation{City = "Wrocław", CountryCode = "PL"},
        };

        private ObservableCollection<WeatherLocation> _weatherLocations;
        public ObservableCollection<WeatherLocation> WeatherLocations
        {
            get => _weatherLocations;
            private set => SetProperty(ref _weatherLocations, value);
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public ICommand ShowAddLocationWizardCommand { get; private set; }
        public ICommand UpdateWeatherLocationsListCommand { get; private set; }
        public ICommand ShowWeatherPresentationPageCommand { get; private set; }

        private async void ShowAddLocationWizard()
        {
            await _pageService.PushAsync(new AddLocationWizard());
        }

        private void UpdateWeatherLocationsList()
        {
            WeatherLocations = new ObservableCollection<WeatherLocation>(_weatherLocationRepository.GetAll());
            IsRefreshing = false;
        }

        private void ShowWeatherPresentationPage(WeatherLocation location)
        {
            _pageService.PushAsync(
                new WeatherPresentation(
                    location));
        }
    }
}
