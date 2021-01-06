using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.App.Models;
using Weather.App.Services;
using Xamarin.Essentials;

namespace Weather.App.Data
{
    class WeatherLocationRepository : IWeatherLocationRepository
    {
        private const string LocationsPreferencesKey = "Locations";

        public void Add(WeatherLocation location)
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                weatherlocationContext.WeatherLocations.Add(location);
                weatherlocationContext.SaveChanges();
            }
        }

        public IEnumerable<WeatherLocation> GetAll()
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                return weatherlocationContext.WeatherLocations.ToList();
            }
        }

        public void Remove(WeatherLocation location)
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                weatherlocationContext.WeatherLocations.Remove(location);
                weatherlocationContext.SaveChanges();
            }
        }
    }
}
