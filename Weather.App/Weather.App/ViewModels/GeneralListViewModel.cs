using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Weather.App.Models;
using Weather.App.Views;
using Xamarin.Forms;

namespace Weather.App.ViewModels
{
    class GeneralListViewModel : BaseViewModel
    {
        public GeneralListViewModel()
        {
            _pageService = new PageService();
            ShowAddLocationWizardCommand = new Command(ShowAddLocationWizard);
        }

        public List<Location> Locations { get; set; } = new List<Location>
        {
            new Location{Name = "Wrocław", Temperature = 20},
        };

        public ICommand ShowAddLocationWizardCommand { get; private set; }

        private async void ShowAddLocationWizard()
        {
            await _pageService.PushAsync(new AddLocationWizard());
        }
    }
}
