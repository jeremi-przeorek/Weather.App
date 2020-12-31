using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.App.Data;
using Weather.App.Models;
using Xamarin.Essentials;

namespace Weather.App.Services
{
    class WeatherLocationRepository : IWeatherLocationRepository
    {
        private const string LocationsPreferencesKey = "Locations";

        public void Add(WeatherLocation location)
        {
            using(var weatherlocationContext = new WeatherLocationContext())
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
    }
}
