using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_03_MVVM.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewBase : ContentPage
    {
        public ViewBase()
        {
            InitializeComponent();
        }
    }
}