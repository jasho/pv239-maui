using CommunityToolkit.Maui.Converters;
using CookBook.Maui.Resources.Fonts;
using CookBook.Mobile.Enums;
using System.Globalization;

namespace CookBook.Maui.Converters;

[AcceptEmptyServiceProvider]
// ReSharper disable once PartialTypeWithSinglePart
public partial class FoodTypeToIconConverter : BaseConverterOneWay<FoodType, string>
{
    public override string ConvertFrom(FoodType value, CultureInfo? culture)
    {
        return value switch
        {
            FoodType.MainDish => FontAwesomeIcons.ConciergeBell,
            FoodType.Soup => FontAwesomeIcons.UtensilSpoon,
            FoodType.Dessert => FontAwesomeIcons.IceCream,
            _ => DefaultConvertReturnValue
        };
    }

    public override string DefaultConvertReturnValue { get; set; } = FontAwesomeIcons.EmptySet;
}