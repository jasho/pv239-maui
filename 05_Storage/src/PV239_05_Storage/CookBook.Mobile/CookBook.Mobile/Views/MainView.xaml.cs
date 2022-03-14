using CookBook.Mobile.Core.ViewModels;

namespace CookBook.Mobile.Views
{
    public partial class MainView
    {
        public MainView(MainViewModel mainViewModel)
            : base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}