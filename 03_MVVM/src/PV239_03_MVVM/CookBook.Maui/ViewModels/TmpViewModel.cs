using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CookBook.Maui.Models;

namespace CookBook.Maui.ViewModels;

public class TmpViewModel : INotifyPropertyChanged
{
    public IngredientDetailModel? Ingredient
    {
        get;
        set
        {
            if (Equals(value, field))
            {
                return;
            }

            field = value;
            OnPropertyChanged();
        }
    }

    public ICommand DoStuffCommand { get; set; }

    public TmpViewModel()
    {
        DoStuffCommand = new Command(DoStuff, CanDoStuff);
    }

    private void DoStuff()
    {
    }

    private bool CanDoStuff()
    {
        return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}