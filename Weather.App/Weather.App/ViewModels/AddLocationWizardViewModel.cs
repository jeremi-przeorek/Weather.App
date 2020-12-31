using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Weather.App.Data;
using Weather.App.Models;
using Weather.App.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    class AddLocationWizardViewModel : BaseViewModel
    {
        private WeatherLocationRepository _weatherLocationRepository = new WeatherLocationRepository();
        private WeatherForecastService _weatherForecastService = new WeatherForecastService();

        public AddLocationWizardViewModel()
        {
            _pageService = DependencyService.Get<IPageService>();
            AddLocationByMyLocationCommand = new Command(AddLocationByMyLocation);
        }


        public ICommand AddLocationByMyLocationCommand { get; private set; }
        public ICommand AddLocationByListCommand { get; private set; }

        private async void AddLocationByMyLocation()
        {
            Location location;

            try
            {
                location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    var weatherLocation = 
                        await _weatherForecastService.GetWeatherLocationByLatLon(location.Latitude, location.Longitude);

                    _weatherLocationRepository.Add(new WeatherLocation
                    {
                        City = weatherLocation.City,
                        CountryCode = weatherLocation.CountryCode,
                    });

                    await _pageService.DisplayAlert(string.Empty, string.Format("Properly added city: {0}", weatherLocation.City), "Ok");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }

}
