using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Weather.App.Data;
using Weather.App.Models;
using Weather.App.Views;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    class GeneralListViewModel : BaseViewModel
    {
        private WeatherLocationRepository _weatherLocationRepository = new WeatherLocationRepository();

        private List<WeatherLocation> _weatherLocations;
        public List<WeatherLocation> WeatherLocations
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

        public GeneralListViewModel()
        {
            WeatherLocations = new List<WeatherLocation>(_weatherLocationRepository.GetAll());

            ShowAddLocationWizardCommand = new Command(ShowAddLocationWizard);
            UpdateWeatherLocationsListCommand = new Command(UpdateWeatherLocationsList);
            ShowWeatherPresentationPageCommand = new Command<WeatherLocation>(ShowWeatherPresentationPage);
            DeleteWeatherLocationEntityCommand = new Command<WeatherLocation>(DeleteWeatherLocationEntity);
        }

        public ICommand ShowAddLocationWizardCommand { get; private set; }
        public ICommand UpdateWeatherLocationsListCommand { get; private set; }
        public ICommand ShowWeatherPresentationPageCommand { get; private set; }
        public ICommand DeleteWeatherLocationEntityCommand { get; private set; }

        private async void ShowAddLocationWizard()
        {
            await _pageService.PushAsync(new AddLocationWizard());
        }

        private void UpdateWeatherLocationsList()
        {
            WeatherLocations = new List<WeatherLocation>(_weatherLocationRepository.GetAll());
            IsRefreshing = false;
        }

        private void ShowWeatherPresentationPage(WeatherLocation location)
        {
            _pageService.PushAsync(
                new WeatherPresentation(
                    location));
        }

        private void DeleteWeatherLocationEntity(WeatherLocation location)
        {
            _weatherLocationRepository.Remove(location);
            UpdateWeatherLocationsList();
        }
    }
}
