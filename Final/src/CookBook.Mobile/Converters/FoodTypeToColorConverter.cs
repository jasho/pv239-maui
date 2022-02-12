using CookBook.Common.Enums;
using CookBook.Mobile.Resources.Styles;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace CookBook.Mobile.Converters
{
    public class FoodTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value switch
            {
                FoodType.MainDish => Color.Blue,
                FoodType.Dessert => Color.Red,
                FoodType.Soup => Color.Green,
                _ => Color.Black
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}