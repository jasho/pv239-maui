using System;

namespace CookBook.Mobile.MAUI.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void IngredientsButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IngredientDetailView());
        }
    }
}