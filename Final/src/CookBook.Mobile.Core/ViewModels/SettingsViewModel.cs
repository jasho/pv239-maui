using CookBook.Mobile.Core.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Mobile.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICollection<string> Languages { get; set; } = new List<string>
        {
            "cs", "en"
        };

        public ICommand SelectLanguageCommand { get; set; }

        public SettingsViewModel(
            ICommandFactory commandFactory)
        {
            SelectLanguageCommand = commandFactory.CreateCommand<string>(SelectLanguageAsync);
        }

        private async Task SelectLanguageAsync(string language)
        {
            // TODO: add functionality
        }
    }
}