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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocationWizard : ContentPage
    {
        public AddLocationWizard()
        {
            InitializeComponent();

            BindingContext = new AddLocationWizardViewModel();
        }
    }
}