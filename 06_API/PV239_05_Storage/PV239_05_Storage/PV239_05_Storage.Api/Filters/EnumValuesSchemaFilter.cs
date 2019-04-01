using System;
using System.Collections.Generic;
using System.Linq;
using PV239_05_Storage.Api.Dtos;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PV239_05_Storage.Api.Filters
{
    public class EnumValuesSchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (context.SystemType.IsEnum)
            {
                IList<EnumValuesSchemaDto> enumValues = new List<EnumValuesSchemaDto>();

                var values = Enum.GetValues(context.SystemType);
                foreach (var value in values)
                {
                    enumValues.Add(new EnumValuesSchemaDto
                    {
                        Name = value.ToString(),
                        Value = Convert.ToInt32(value)
                    });
                }

                schema.Enum = new List<object>();
                var intValues = enumValues.Select(enumValue => enumValue.Value);
                foreach (var value in intValues)
                {
                    schema.Enum.Add(value);
                }
                schema.Extensions.Add(
                    "x-ms-enum",
                    new
                    {
                        name = context.SystemType.Name,
                        modelAsString = false,
                        values = enumValues.ToArray()
                    });
            }
        }
    }
}