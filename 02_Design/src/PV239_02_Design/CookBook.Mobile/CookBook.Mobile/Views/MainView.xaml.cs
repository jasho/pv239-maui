using System;

namespace CookBook.Mobile.Views
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