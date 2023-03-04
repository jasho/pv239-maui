using CommunityToolkit.Maui.Converters;
using CookBook.Mobile.Enums;
using System.Globalization;

namespace CookBook.Mobile.Converters;

public class FoodTypeToColorConverter : BaseConverterOneWay<FoodType, Color>
{
    public override Color ConvertFrom(FoodType value, CultureInfo? culture)
    {
        var color = Colors.Grey;

        if (Application.Current?.Resources.TryGetValue($"{value}FoodTypeColor", out var resourceValue) is true
            && resourceValue is Color resourceColor)
        {
            color = resourceColor;
        }

        return color;
    }

    public override Color DefaultConvertReturnValue { get; set; } = Colors.Grey;
}