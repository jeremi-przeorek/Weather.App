using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
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
        private WeatherLocation _location;

        public WeatherPresentationViewModel(WeatherLocation location)
        {
            _location = location;
            YBindingPath = "Temp";
            Title = string.Format("Weather forecast for {0}", location.City);
            DailyForecastDtos = new ObservableCollection<DailyForecastDto>();

            GetWeatherDataCommand = new Command(async () => await GetWeatherData());
            ChangeSelectedDayCommand = new Command<int>(ChangeSelectedDay);
        }

        private bool _isDataLoading;
        public bool IsDataLoading
        {
            get { return _isDataLoading; }
            set { SetProperty(ref _isDataLoading, value); }
        }

        public ICommand GetWeatherDataCommand { get; private set; }
        public ICommand ChangeSelectedDayCommand { get; private set; }

        private async Task GetWeatherData()
        {
            IsDataLoading = true;
            var dailyForecast16DaysDto = await _weatherForecastService.GetDailyForecastFor16Days(_location);
            DailyForecastDtos
                = new ObservableCollection<DailyForecastDto>(dailyForecast16DaysDto.Data);
            IsDataLoading = false;
        }

        private void ChangeSelectedDay(int selectedDayIndex)
        {
            SelectedDayForecast = DailyForecastDtos[selectedDayIndex];
        }

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

        private int _selectedDay;
        public int SelectedDay
        {
            get { return _selectedDay; }
            set { SetProperty(ref _selectedDay, value); }
        }

        private DailyForecastDto _selectedDayForecast;
        public DailyForecastDto SelectedDayForecast
        {
            get { return _selectedDayForecast; }
            set { SetProperty(ref _selectedDayForecast, value); }
        }
    }
}
