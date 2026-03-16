using BluetoothSampleApp.ViewModels;

namespace BluetoothSampleApp.Pages;

/// <summary>
/// Base page that automatically calls <see cref="BaseViewModel.OnPageLoaded"/>
/// when the page appears.
/// </summary>
public class PageBase : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.OnPageLoaded();
        }
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.OnPageUnloaded();
        }
    }
}
