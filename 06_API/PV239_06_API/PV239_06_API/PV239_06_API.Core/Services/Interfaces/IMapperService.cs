using System;
using System.Collections.Generic;
using PV239_06_API.Core.Mappings;

namespace PV239_06_API.Core.Services.Interfaces
{
    public interface IMapperService : ISingletonService
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        object Map(object source, Type sourceType, Type destinationType);
        object Map(object source, object destination, Type sourceType, Type destinationType);
        void Initialize(IEnumerable<IMapping> mappings);
    }
}