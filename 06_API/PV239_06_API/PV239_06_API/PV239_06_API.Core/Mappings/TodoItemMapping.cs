using AutoMapper;
using PV239_06_API.Core.Api.Models;
using PV239_06_API.Core.Models;

namespace PV239_06_API.Core.Mappings
{
    public class TodoItemMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<TodoItemDtoInner, TodoItemModel>();
            mapperConfiguration.CreateMap<TodoItemModel, TodoItemDtoInner>();
        }
    }
}