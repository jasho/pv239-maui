using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PV239_03_MVVM.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_03_MVVM.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorView : ContentPage
    {
        public CalculatorView()
        {
            BindingContext = new CalculatorViewModel();
            InitializeComponent();
        }
    }
}