using System.Threading.Tasks;
using System.Windows.Input;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;

namespace PV239_06_API.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISecureStorageService secureStorageService;
        private readonly INavigationService navigationService;
        public string Username { get; set; }
        public string Language { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public SettingsViewModel(
            ICommandFactory commandFactory,
            ISecureStorageService secureStorageService,
            INavigationService navigationService)
        {
            this.secureStorageService = secureStorageService;
            this.navigationService = navigationService;
            CancelCommand = commandFactory.CreateCommand(Cancel, () => true);
            SaveCommand = commandFactory.CreateCommand(Save, () => true);
        }

        public override async Task OnAppearing()
        {
            Username = await secureStorageService.GetAsync("Username") ?? string.Empty;
            Language = await secureStorageService.GetAsync("Language") ?? string.Empty;
            await base.OnAppearing();
        }

        private async void Cancel()
        {
            await navigationService.PopAsync();
        }

        private async void Save()
        {
            await secureStorageService.SetAsync("Username", Username);
            await secureStorageService.SetAsync("Language", Language);
            await navigationService.PopAsync();
        }
    }
}