using System;
using Weather.App.ViewModels;
using Weather.App.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.App
{
    public partial class App : Application
    {

        public App()
        {
            DependencyService.Register<IPageService, PageService>();

            MainPage = (new NavigationPage(new GeneralListPage()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
