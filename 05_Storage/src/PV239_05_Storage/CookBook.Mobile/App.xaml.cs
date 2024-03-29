﻿using CookBook.Mobile.Resources.Styles;
using CookBook.Mobile.ViewModels;
using CookBook.Mobile.Views.Ingredient;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Mobile;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		ApplyPreferences(serviceProvider.GetRequiredService<IPreferences>());

		MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Width = 480;
        window.Height = 800;

        return window;
    }

    protected override async void OnStart()
    {
        base.OnStart();
    }

	private static void ApplyPreferences(IPreferences preferences) {
		var theme = (Theme)preferences.Get(nameof(SettingsViewModel.SelectedTheme), 2);
		var culture = preferences.Get(nameof(SettingsViewModel.SelectedLanguage), Thread.CurrentThread.CurrentCulture.IetfLanguageTag.Split('-')[0]);
		Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
		Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
		if (theme == Theme.System) {
			theme = ResolveSystemTheme();
		}
		if (theme == Theme.Dark) {
			return; // Dark is the default
		}
		var defaultTheme = Application.Current.Resources.MergedDictionaries.First(f => f.ContainsKey(nameof(View.BackgroundColor)));
		Application.Current.Resources.MergedDictionaries.Remove(defaultTheme);
		Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
	}

	private static Theme ResolveSystemTheme() {
		return Application.Current.RequestedTheme switch {
			AppTheme.Light => Theme.Light,
			AppTheme.Dark => Theme.Dark,
			_ => Theme.Dark
		};
	}
}
