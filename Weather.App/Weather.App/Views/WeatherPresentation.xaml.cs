using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.App.Models;
using Weather.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPresentation : ContentPage
    {
        public WeatherPresentation(WeatherLocation location)
        {
            InitializeComponent();

            BindingContext = new WeatherPresentationViewModel(location);
        }

        private WeatherPresentationViewModel ViewModel
        {
            get { return BindingContext as WeatherPresentationViewModel; }
            set { BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            ViewModel.GetWeatherDataCommand.Execute(null);

            base.OnAppearing();
        }
        private void Chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
            if (e.SelectedDataPointIndex > -1)
            {
                ViewModel.ChangeSelectedDayCommand.Execute(e.SelectedDataPointIndex);
            }
        }
    }
}