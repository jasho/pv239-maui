using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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