﻿using CommunityToolkit.Maui.Converters;
using CookBook.Mobile.Enums;
using System.Globalization;

namespace CookBook.Maui.Converters;

[AcceptEmptyServiceProvider]
// ReSharper disable once PartialTypeWithSinglePart
public partial class FoodTypeToColorConverter : BaseConverterOneWay<FoodType, Color>
{
    public override Color ConvertFrom(FoodType value, CultureInfo? culture)
    {
        var color = DefaultConvertReturnValue;

        if (Application.Current?.Resources.TryGetValue($"{value}FoodTypeColor", out var resourceValue) is true
            && resourceValue is Color resourceColor)
        {
            color = resourceColor;
        }

        return color;
    }

    public override Color DefaultConvertReturnValue { get; set; } = Colors.Grey;
}