using AutoMapper;
using PV239_05_Storage.Core.Api.Models;
using PV239_05_Storage.Core.Models;

namespace PV239_05_Storage.Core.Mappings
{
    public class TodoItemMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<TodoItemDtoInner, TodoItemModel>();
        }
    }
}