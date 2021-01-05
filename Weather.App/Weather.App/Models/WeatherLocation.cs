using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.App.Models
{
    public class WeatherLocation
    {
        public int Id { get; set; }
        [JsonProperty("city_name")]
        public string City { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
