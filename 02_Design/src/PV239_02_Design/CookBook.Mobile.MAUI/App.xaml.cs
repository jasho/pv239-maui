using CookBook.Mobile.MAUI.Views;

namespace CookBook.Mobile.MAUI {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new NavigationPage(new MainView());
		}
	}
}