using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PV239_06_API.Core.Api;
using PV239_06_API.Core.Api.Models;
using PV239_06_API.Core.Factories.Interfaces;
using PV239_06_API.Core.Models;
using PV239_06_API.Core.Services.Interfaces;
using PV239_06_API.Core.ViewModels.Base;

namespace PV239_06_API.Core.ViewModels
{
    public class TodoDetailViewModel : ViewModelBase<Guid?>
    {
        private readonly IApiClient apiClient;
        private readonly IMapperService mapperService;
        private readonly INavigationService navigationService;
        public TodoItemModel TodoItem { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public TodoDetailViewModel(
            Guid? viewModelParameter,
            ICommandFactory commandFactory,
            IApiClient apiClient,
            IMapperService mapperService,
            INavigationService navigationService)
            : base(viewModelParameter)
        {
            this.apiClient = apiClient;
            this.mapperService = mapperService;
            this.navigationService = navigationService;

            SaveCommand = commandFactory.CreateCommand(Save, () => true);
            CancelCommand = commandFactory.CreateCommand(Cancel, () => true);
        }

        private async void Cancel()
        {
            await navigationService.PopAsync();
        }

        private async void Save()
        {
            await apiClient.TodoInsertOrUpdateItemAsync(mapperService.Map<TodoItemDtoInner>(TodoItem));
            await navigationService.PopAsync();
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            if (viewModelParameter != null)
            {
                var todoItemDto = await apiClient.TodoGetItemAsync(viewModelParameter.Value);
                TodoItem = mapperService.Map<TodoItemModel>(todoItemDto);
            }
            else
            {
                TodoItem = new TodoItemModel
                {
                    Title = string.Empty,
                    IsCompleted = false
                };
            }
        }
    }
}