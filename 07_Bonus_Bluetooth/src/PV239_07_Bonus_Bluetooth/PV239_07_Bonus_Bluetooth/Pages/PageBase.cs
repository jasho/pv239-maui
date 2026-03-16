using PV239_07_Bonus_Bluetooth.ViewModels;

namespace PV239_07_Bonus_Bluetooth.Pages;

/// <summary>
/// Base page that automatically calls <see cref="BaseViewModel.OnPageLoaded"/>
/// when the page appears.
/// </summary>
public class PageBase : ContentPage
{
    protected override async void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel viewModel)
            {
                await viewModel.OnPageLoaded();
            }
        }
        catch (Exception e)
        {
            // Log the exception or show an error message as appropriate
            Console.WriteLine($"Error in OnAppearing: {e}");
        }
    }

    protected override async void OnDisappearing()
    {
        try
        {
            base.OnDisappearing();

            if (BindingContext is BaseViewModel viewModel)
            {
                await viewModel.OnPageUnloaded();
            }
        }
        catch (Exception e)
        {
            // Log the exception or show an error message as appropriate
            Console.WriteLine($"Error in OnDisappearing: {e}");
        }
    }
}
