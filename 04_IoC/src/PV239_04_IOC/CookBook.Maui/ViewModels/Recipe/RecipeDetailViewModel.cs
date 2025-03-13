using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Maui.Models;
using CookBook.Mobile.Enums;

namespace CookBook.Maui.ViewModels.Recipe;

public partial class RecipeDetailViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial RecipeDetailModel? Recipe { get; set; } = new()
    {
        Id = Guid.NewGuid(),
        Name = "Míchaná vejce",
        Description = "K přípravě míchaných vajec jsou třeba vejce, cibule, tuk, sůl a popřípadě též uzenina a na dozdobení pažitka nebo petrželka. Na tuku se dozlatova osmaží cibulka. Následně se do ní přidá uzenina (je-li jako přísada zvolena) a nechá se osmahnout. Dále se do směsi přidají celá vejce. Pokrm se osolí a za stálého míchání se nechá ztuhnout. Závěrem je možné dozdobit pažitkou nebo petrželkou.[6]",
        FoodType = FoodType.MainDish,
        ImageUrl = "https://i.ibb.co/mJgrX6B/Scrambled-eggs-01.jpg"
    };
}