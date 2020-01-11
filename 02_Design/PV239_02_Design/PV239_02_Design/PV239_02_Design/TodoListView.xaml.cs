using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PV239_02_Design
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();
        }

        private void NewItemClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TodoItemView());
        }
    }
}