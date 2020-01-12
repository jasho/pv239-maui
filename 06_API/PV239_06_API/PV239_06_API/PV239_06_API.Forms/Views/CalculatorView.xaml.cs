using PV239_06_API.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PV239_06_API.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorView
    {
        public CalculatorView(CalculatorViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}