using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using GraphQL;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using uit.ooad.Businesses;
using uit.ooad.GraphQLHelper;
using uit.ooad.Models;
using uit.ooad.Queries.Helper;

namespace uit.ooad.test.Helper
{
    public static class SchemaHelper
    {
        public static void Execute(
            string queryPath,
            string schemaPath,
            string variablePath = null,
            Action<Position> setPermission = null
        )
        {
            var variable = variablePath == null ? "{}" : File.ReadAllText(variablePath.TrimStart('/'));
            var query = File.ReadAllText(queryPath.TrimStart('/'));
            var schema = File.ReadAllText(schemaPath.TrimStart('/'));

            var User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, Constant.UserName)
                    }
                )
            );

            var position = EmployeeBusiness.Get(Constant.UserName).Position;

            if (setPermission != null) PositionBusiness.UpdateForHelper(setPermission, position);

            var result = Initializer.Schema.Execute(_ =>
            {
                _.Query = query;
                _.Inputs = JObject.Parse(variable).ToInputs();
                _.UserContext = new GraphQLUserContext
                {
                    User = User
                };
            });

            var jsonResult = JObject.Parse(result);
            var jSchema = JSchema.Parse(schema);

            var isValid = jsonResult.IsValid(jSchema, out IList<string> errorMessages);
            var errorMessagesString = string.Join("\n", errorMessages);
            var exceptionMessage = string.Join(
                Environment.NewLine,
                "",
                "Query:", query,
                "Result:", jsonResult.ToString(),
                "Error Messages:", errorMessagesString
            );

            if (!isValid) throw new Exception(exceptionMessage);
        }
    }
}
