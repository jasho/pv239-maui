using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using PV239_06_API.Api.Dtos;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PV239_06_API.Api.Filters
{
    public class EnumValuesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                //IList<EnumValuesSchemaDto> enumValues = new List<EnumValuesSchemaDto>();

                //var values = Enum.GetValues(context.Type);
                //foreach (var value in values)
                //{
                //    enumValues.Add(new EnumValuesSchemaDto
                //    {
                //        Name = value.ToString(),
                //        Value = Convert.ToInt32(value)
                //    });
                //}

                //schema.Enum = new List<IOpenApiAny>();
                //var intValues = enumValues.Select(enumValue => enumValue.Value);
                //var enumValuesArray = new OpenApiArray();
                //foreach (var value in intValues)
                //{
                //    schema.Enum.Add(new OpenApiInteger(value));
                //    enumValuesArray.Add(new OpenApiInteger(value));
                //}

                //schema.Extensions.Add("x-ms-enum", enumValuesArray);

                //schema.Extensions.Add(
                //    "x-ms-enum",
                //    new
                //    {
                //        name = context.Type.Name,
                //        modelAsString = false,
                //        values = enumValues.ToArray()
                //    });
            }
        }
    }
}