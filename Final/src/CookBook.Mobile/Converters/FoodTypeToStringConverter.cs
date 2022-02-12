using CookBook.Common.Resources.Texts;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace CookBook.Mobile.Converters
{
    public class FoodTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FoodTypeTexts.ResourceManager.GetString(value.ToString())
                   ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}