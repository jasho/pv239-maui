using CookBook.Mobile.Views.Ingredient;

namespace CookBook.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new IngredientListView();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Width = 480;
        window.Height = 800;

        return window;
    }
}
