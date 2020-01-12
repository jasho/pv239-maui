using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using PV239_06_API.Core.Mappings;
using PV239_06_API.Core.Services.Interfaces;

namespace PV239_06_API.Core.Services
{
    public class MapperService : IMapperService
    {
        private IMapper mapper;

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map<TSource, TDestination>(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return mapper.Map(source, destination, sourceType, destinationType);
        }

        public void Initialize(IEnumerable<IMapping> mappings)
        {

            var mapperConfigurationExpression = new MapperConfigurationExpression();
            try
            {
                mapperConfigurationExpression = new MapperConfigurationExpression();
                var mappingsList = mappings.ToList();
                foreach (var mapping in mappingsList)
                {
                    mapping.ConfigureMaps(mapperConfigurationExpression);
                }
            }
            catch (InvalidOperationException exception)
                when (exception.Source == "AutoMapper"
                      && exception.Message == "Mapper already initialized. You must call Initialize once per application domain/process.")
            {
            }

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
            mapperConfiguration.AssertConfigurationIsValid();
            mapper = mapperConfiguration.CreateMapper();
        }
    }
}