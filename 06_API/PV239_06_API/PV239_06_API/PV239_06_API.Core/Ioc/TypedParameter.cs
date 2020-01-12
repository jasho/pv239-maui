using System;

namespace PV239_06_API.Core.Ioc
{
    public class TypedParameter
    {
        public Type Type { get; }
        public object Value { get; }

        public TypedParameter(Type type, object value)
        {
            Type = type;
            Value = value;
        }
    }
}