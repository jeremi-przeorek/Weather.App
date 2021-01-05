using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Weather.App.Models;

namespace Weather.App.Data
{
    public static class ResourcesLoader
    {
        private static List<WeatherLocation> _weatherLocations;
        public static async Task<List<WeatherLocation>> LoadWeatherLocations()
        {
            if(_weatherLocations != null)
            {
                return _weatherLocations;
            }

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ResourcesLoader)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Weather.App.Resources.cities_20000.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                _weatherLocations = await Task.Run(() => JsonConvert.DeserializeObject<List<WeatherLocation>>(reader.ReadToEnd()));
                return _weatherLocations;
            }
        }
    }
}
