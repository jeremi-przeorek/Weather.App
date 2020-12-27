using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    class AddLocationWizardViewModel : BaseViewModel
    {
        public AddLocationWizardViewModel()
        {
            _pageService = DependencyService.Get<IPageService>();
            AddLocationByMyLocationCommand = new Command(AddLocationByMyLocation);
        }

        public ICommand AddLocationByMyLocationCommand { get; private set; }
        public ICommand AddLocationByListCommand { get; private set; }

        private async void AddLocationByMyLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    await _pageService.DisplayAlert("Lokalizacja:", 
                        $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}",
                        "cancel");
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
