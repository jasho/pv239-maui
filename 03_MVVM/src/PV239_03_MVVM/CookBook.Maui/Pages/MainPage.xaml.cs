namespace CookBook.Maui.Pages;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void IngredientsButton_OnClicked(object? sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//ingredient-detail");
        Shell.Current.GoToAsync("./ingredient-detail");
    }
}