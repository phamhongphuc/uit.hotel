using System;
using System.Collections.Generic;
using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.test.Helper
{
    public static class SchemaHelper
    {
        public static void Execute(string queryPath, string schemaPath, string variablePath = null)
        {
            var variable = variablePath == null ? "{}" : File.ReadAllText(variablePath.TrimStart('/'));
            var query = File.ReadAllText(queryPath.TrimStart('/'));
            var schema = File.ReadAllText(schemaPath.TrimStart('/'));

            var result = Initializer.Schema.Execute(_ =>
            {
                _.Query = query;
                _.Inputs = JObject.Parse(variable).ToInputs();
            });

            var json = JObject.Parse(result);
            var jSchema = JSchema.Parse(schema);

            var isValid = json.IsValid(jSchema, out IList<string> messages);

            var errorMessage = string.Join("\n", messages) + "\n\n" + json.ToString();

            if (!isValid) throw new Exception(errorMessage);
        }
    }
}