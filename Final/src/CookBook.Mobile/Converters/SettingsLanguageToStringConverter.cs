using CookBook.Mobile.Resources.Texts;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace CookBook.Mobile.Converters
{
    public class SettingsLanguageToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return SettingsViewTexts.ResourceManager.GetString($"Language_{value}_Picker_ItemDiplayBinding")
                   ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}