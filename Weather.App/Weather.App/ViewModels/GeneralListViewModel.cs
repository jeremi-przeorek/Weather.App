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

        public ICommand ShowAddLocationWizardCommand { get; private set; }

        private async void ShowAddLocationWizard()
        {
            await _pageService.PushAsync(new AddLocationWizard());
        }
    }
}
