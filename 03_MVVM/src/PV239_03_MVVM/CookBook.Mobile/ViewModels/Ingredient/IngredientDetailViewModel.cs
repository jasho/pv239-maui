using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Mobile.Models;

namespace CookBook.Mobile.ViewModels.Ingredient;

public partial class IngredientDetailViewModel : ViewModelBase
{
    [ObservableProperty]
    private IngredientDetailModel? ingredient = new()
    {
        Id = Guid.NewGuid(),
        Name = "Vejce",
        Description = "Základní význam vajec domácí drůbeže je v první řadě biologický, tj. zajistit reprodukci daného druhu. Protože k vývoji nového jedince dochází mimo tělo matky, obsahuje vejce všechny důležité výživné složky nezbytné pro vývoj nového organismu. Zatímco vejce krůt, kachen a hus jsou produkována hlavně pro účely reprodukční, tj. slouží jako vejce násadová, slepičí vejce slouží také jako vejce konzumní a mohou být součástí lidské výživy. Vejce mají vysoký obsah plnohodnotných bílkovin (obsahují všechny aminokyseliny pro člověka nezbytné a to v poměru, který je nejpříznivější ze všech běžných potravin). Vejce dále obsahují tuky, vitamíny a minerální látky. Avšak obsahují i vysoké množství cholesterolu, takže konzumace 3 a více vajec denně prokazatelně zvyšuje riziko onemocnění a smrti.[1]",
        ImageUrl = "https://i.ibb.co/d7mZWGN/image.jpg",
    };

    [RelayCommand]
    private void Share()
    {
    }

    [RelayCommand]
    private void Delete()
    {
    }

    [RelayCommand]
    private void GoToEdit()
    {
    }
}