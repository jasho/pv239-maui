using CookBook.Mobile.Core.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace CookBook.Mobile.Converters;

public class AppStateToCommunityToolkitLayoutStateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            AppState state => state switch
            {
                AppState.None => Xamarin.CommunityToolkit.UI.Views.LayoutState.None,
                AppState.Loading => Xamarin.CommunityToolkit.UI.Views.LayoutState.Loading,
                AppState.Saving => Xamarin.CommunityToolkit.UI.Views.LayoutState.Saving,
                AppState.Success => Xamarin.CommunityToolkit.UI.Views.LayoutState.Success,
                AppState.Error => Xamarin.CommunityToolkit.UI.Views.LayoutState.Error,
                AppState.Empty => Xamarin.CommunityToolkit.UI.Views.LayoutState.Empty,
                _ => throw new ArgumentOutOfRangeException()
            },
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            Xamarin.CommunityToolkit.UI.Views.LayoutState state => state switch
            {
                Xamarin.CommunityToolkit.UI.Views.LayoutState.None => AppState.None,
                Xamarin.CommunityToolkit.UI.Views.LayoutState.Loading => AppState.Loading,
                Xamarin.CommunityToolkit.UI.Views.LayoutState.Saving => AppState.Saving,
                Xamarin.CommunityToolkit.UI.Views.LayoutState.Success => AppState.Success,
                Xamarin.CommunityToolkit.UI.Views.LayoutState.Error => AppState.Error,
                Xamarin.CommunityToolkit.UI.Views.LayoutState.Empty => AppState.Empty,
                _ => throw new ArgumentOutOfRangeException()
            },
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}