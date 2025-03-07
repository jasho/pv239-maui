using CookBook.Maui.Pages.Ingredient;

namespace CookBook.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new IngredientEditPage());
        }
    }
}