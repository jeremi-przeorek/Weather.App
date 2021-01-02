using System;
using System.Collections.Generic;
using System.Text;
using Weather.App.Models;

namespace Weather.App.Data
{
    interface IWeatherLocationRepository
    {
        IEnumerable<WeatherLocation> GetAll();
        void Add(WeatherLocation location);
        void Remove(WeatherLocation location);
    }
}
