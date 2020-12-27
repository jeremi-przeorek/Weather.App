using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}