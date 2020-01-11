using PV239_03_MVVM.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PV239_03_MVVM.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorView
    {
        public CalculatorView()
        {
            BindingContext = new CalculatorViewModel();
            InitializeComponent();
        }
    }
}