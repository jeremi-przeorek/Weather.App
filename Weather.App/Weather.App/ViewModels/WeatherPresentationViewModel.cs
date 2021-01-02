using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.App.Models;
using Weather.App.Services;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    public class WeatherPresentationViewModel : BaseViewModel
    {
        private WeatherForecastService _weatherForecastService = new WeatherForecastService();
        public WeatherPresentationViewModel(WeatherLocation location)
        {
            Location = location;
            YBindingPath = "Temp";

            GetWeatherDataCommand = new Command(async () => GetWeatherData());
        }

        public ICommand GetWeatherDataCommand { get; private set; }

        private async Task GetWeatherData()
        {
            DailyForecast16DaysDto = await _weatherForecastService.GetDailyForecastFor16Days(Location);
            DailyForecastDtos 
                = new ObservableCollection<DailyForecastDto>(DailyForecast16DaysDto.Data);
        }

        public WeatherLocation Location { get; set; }

        private ObservableCollection<DailyForecastDto> _dailyForecastDtos;
        public ObservableCollection<DailyForecastDto> DailyForecastDtos
        {
            get { return _dailyForecastDtos; }
            set { SetProperty(ref _dailyForecastDtos, value); }
        }

        private string _yBindingPath;

        public string YBindingPath
        {
            get { return _yBindingPath; }
            set { SetProperty(ref _yBindingPath, value); }
        }


        private DailyForecast16DaysDto _dailyForecast16DaysDto;
        public DailyForecast16DaysDto DailyForecast16DaysDto
        {
            get { return _dailyForecast16DaysDto; }
            set { SetProperty(ref _dailyForecast16DaysDto, value); }
        }
    }
}
