using AutoMapper;
using PV239_05_Storage.Core.Mappings;
using System;
using System.Collections.Generic;
using PV239_05_Storage.Core.Services.Interfaces;

namespace PV239_05_Storage.Core.Services
{
    public class MapperService : IMapperService
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, destination, sourceType, destinationType);
        }

        public void Initialize(IEnumerable<IMapping> mappings)
        {
            try
            {
                Mapper.Initialize(configuration =>
                {
                    foreach (var mapping in mappings)
                    {
                        mapping.ConfigureMaps(configuration);
                    }
                });
            }
            catch (InvalidOperationException exception)
                when (exception.Source == "AutoMapper"
                      && exception.Message == "Mapper already initialized. You must call Initialize once per application domain/process.")
            {

            }
        }
    }
}