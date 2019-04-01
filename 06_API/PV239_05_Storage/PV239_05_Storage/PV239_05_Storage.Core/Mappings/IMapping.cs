using AutoMapper;

namespace PV239_05_Storage.Core.Mappings
{
    public interface IMapping
    {
        void ConfigureMaps(IMapperConfigurationExpression mapperConfiguration);
    }
}