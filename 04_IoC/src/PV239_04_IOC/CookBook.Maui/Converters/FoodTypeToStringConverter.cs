using CommunityToolkit.Maui.Converters;
using CookBook.Maui.Resources.Texts;
using CookBook.Mobile.Enums;
using System.Globalization;

namespace CookBook.Maui.Converters;

[AcceptEmptyServiceProvider]
// ReSharper disable once PartialTypeWithSinglePart
public partial class FoodTypeToStringConverter : BaseConverterOneWay<FoodType, string>
{
    public override string ConvertFrom(FoodType value, CultureInfo? culture)
        => FoodTypeTexts.ResourceManager.GetString(value.ToString(), culture)
           ?? DefaultConvertReturnValue;

    public override string DefaultConvertReturnValue { get; set; } = FoodTypeTexts.Unknown;
}