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

        private bool _isDataLoading;
        public bool IsDataLoading
        {
            get { return _isDataLoading; }
            set { SetProperty(ref _isDataLoading, value); }
        }

        private List<DailyForecastDto> _dailyForecastDtos;
        public List<DailyForecastDto> DailyForecastDtos
        {
            get { return _dailyForecastDtos; }
            set { SetProperty(ref _dailyForecastDtos, value); }
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

        public WeatherPresentationViewModel(WeatherLocation location)
        {
            _location = location;

            Title = string.Format("Weather forecast for {0}", location.City);

            DailyForecastDtos = new List<DailyForecastDto>();

            GetWeatherDataCommand = new Command(async () => await GetWeatherData());
            ChangeSelectedDayCommand = new Command<int>(ChangeSelectedDay);
        }

        public ICommand GetWeatherDataCommand { get; private set; }
        public ICommand ChangeSelectedDayCommand { get; private set; }

        private async Task GetWeatherData()
        {
            IsDataLoading = true;
            var dailyForecast16DaysDto = await _weatherForecastService.GetDailyForecastFor16Days(_location);
            IsDataLoading = false;
            
            if(dailyForecast16DaysDto == null)
            {
                await _pageService.DisplayAlert("Error", "There was problem with getting your data :(", "Ok");
                return;
            }

            DailyForecastDtos = new List<DailyForecastDto>(dailyForecast16DaysDto.Data);
        }

        private void ChangeSelectedDay(int selectedDayIndex)
        {
            SelectedDayForecast = DailyForecastDtos[selectedDayIndex];
        }
    }
}
