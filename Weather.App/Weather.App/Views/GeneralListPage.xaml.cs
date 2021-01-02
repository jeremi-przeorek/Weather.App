using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.App.Models;
using Weather.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.App.Views
{
    public partial class GeneralListPage : ContentPage
    {
        public GeneralListPage()
        {
            InitializeComponent();

            BindingContext = new GeneralListViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ShowWeatherPresentationPageCommand.Execute(e.Item);
        }

        protected override void OnAppearing()
        {
            ViewModel.UpdateWeatherLocationsListCommand.Execute(null);

            base.OnAppearing();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            ViewModel.DeleteWeatherLocationEntityCommand.Execute(mi.CommandParameter);
        }
        private GeneralListViewModel ViewModel
        {
            get { return BindingContext as GeneralListViewModel; }
            set { BindingContext = value; }
        }
    }
}