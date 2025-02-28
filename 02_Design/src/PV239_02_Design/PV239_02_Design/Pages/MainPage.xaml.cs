namespace PV239_02_Design.Pages;

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