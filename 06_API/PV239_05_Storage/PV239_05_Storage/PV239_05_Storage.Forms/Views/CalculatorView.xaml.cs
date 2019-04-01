using PV239_05_Storage.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_05_Storage.Forms.Views
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