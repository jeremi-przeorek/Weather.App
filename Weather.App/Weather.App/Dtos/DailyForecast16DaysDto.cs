using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.App.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class WeatherDto
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class DailyForecastDto
    {
        [JsonProperty("moonrise_ts")]
        public int MoonriseTs { get; set; }

        [JsonProperty("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonProperty("rh")]
        public int Rh { get; set; }

        [JsonProperty("pres")]
        public double Pres { get; set; }

        [JsonProperty("high_temp")]
        public double HighTemp { get; set; }

        [JsonProperty("sunset_ts")]
        public int SunsetTs { get; set; }

        [JsonProperty("ozone")]
        public double Ozone { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("wind_gust_spd")]
        public double WindGustSpd { get; set; }

        [JsonProperty("snow_depth")]
        public double SnowDepth { get; set; }

        [JsonProperty("clouds")]
        public int Clouds { get; set; }

        [JsonProperty("ts")]
        public int Ts { get; set; }

        [JsonProperty("sunrise_ts")]
        public int SunriseTs { get; set; }

        [JsonProperty("app_min_temp")]
        public double AppMinTemp { get; set; }

        [JsonProperty("wind_spd")]
        public double WindSpd { get; set; }

        [JsonProperty("pop")]
        public int Pop { get; set; }

        [JsonProperty("wind_cdir_full")]
        public string WindCdirFull { get; set; }

        [JsonProperty("slp")]
        public double Slp { get; set; }

        [JsonProperty("moon_phase_lunation")]
        public double MoonPhaseLunation { get; set; }

        [JsonProperty("valid_date")]
        public string ValidDate { get; set; }

        [JsonProperty("app_max_temp")]
        public double AppMaxTemp { get; set; }

        [JsonProperty("vis")]
        public double Vis { get; set; }

        [JsonProperty("dewpt")]
        public double Dewpt { get; set; }

        [JsonProperty("snow")]
        public double Snow { get; set; }

        [JsonProperty("uv")]
        public double Uv { get; set; }

        [JsonProperty("weather")]
        public WeatherDto Weather { get; set; }

        [JsonProperty("wind_dir")]
        public int WindDir { get; set; }

        [JsonProperty("max_dhi")]
        public object MaxDhi { get; set; }

        [JsonProperty("clouds_hi")]
        public int CloudsHi { get; set; }

        [JsonProperty("precip")]
        public double Precip { get; set; }

        [JsonProperty("low_temp")]
        public double LowTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("moonset_ts")]
        public int MoonsetTs { get; set; }

        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("clouds_mid")]
        public int CloudsMid { get; set; }

        [JsonProperty("clouds_low")]
        public int CloudsLow { get; set; }
    }

    public class DailyForecast16DaysDto
    {
        [JsonProperty("data")]
        public List<DailyForecastDto> Data { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }
    }
}
