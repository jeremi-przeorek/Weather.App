using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.App.Models
{
    class WeatherLocation
    {
        public int Id { get; set; }
        public string City { get; set; }

        public string CountryCode { get; set; }
    }
}
