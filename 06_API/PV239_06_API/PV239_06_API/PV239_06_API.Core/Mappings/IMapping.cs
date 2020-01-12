using AutoMapper;

namespace PV239_06_API.Core.Mappings
{
    public interface IMapping
    {
        void ConfigureMaps(IMapperConfigurationExpression mapperConfiguration);
    }
}