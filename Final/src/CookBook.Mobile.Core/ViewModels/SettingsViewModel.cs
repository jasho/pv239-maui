using CookBook.Mobile.Core.Factories;
using CookBook.Mobile.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IPreferencesService preferencesService;

        public ICollection<string> Languages { get; set; } = new List<string>
        {
            "cs", "en"
        };

        public string SelectedLanguage { get; set; }
        public ICommand SelectLanguageCommand { get; set; }
        
        public SettingsViewModel(
            ICommandFactory commandFactory,
            IPreferencesService preferencesService)
        {
            this.preferencesService = preferencesService;
            SelectLanguageCommand = commandFactory.CreateCommand(SelectLanguageAsync);
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            SelectedLanguage = preferencesService.Get(PreferencesKeys.LanguageKey, "cs");
        }

        private async Task SelectLanguageAsync()
        {
            preferencesService.Set(PreferencesKeys.LanguageKey, SelectedLanguage);
        }
    }
}