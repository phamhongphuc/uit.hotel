using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Validation;
using Newtonsoft.Json;
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
            var result = ExecuteAsync(queryPath, variablePath, setPermission).GetAwaiter().GetResult();
            var jsonResult = JObject.Parse(
                JsonConvert.SerializeObject(
                    new { data = result.Result.Data }
                )
            );
            var jSchema = JSchema.Parse(
                File.ReadAllText(schemaPath.TrimStart('/'))
            );

            var isValid = jsonResult.IsValid(jSchema, out IList<string> errorMessages);

            if (!isValid)
            {
                var errorMessage = string.Join(
                    Environment.NewLine,
                    "",
                    "Query:", result.Query,
                    "Result:", jsonResult.ToString(),
                    "Error Messages:", string.Join("\n", errorMessages)
                );
                throw new Exception(errorMessage);
            }
        }

        public static void ExecuteAndExpectError(
            string expectErrorMessage,
            string queryPath,
            string variablePath = null,
            Action<Position> setPermission = null
        )
        {
            var result = ExecuteAsync(queryPath, variablePath, setPermission).GetAwaiter().GetResult();
            var message = "";
            try
            {
                message = result.Result.Errors[0].InnerException.Message;
            }
            catch (Exception e)
            {
                var errorMessage = string.Join(
                    Environment.NewLine,
                    "",
                    "Query:", result.Query,
                    "Variable:", result.Variable,
                    "Exception:", e.ToString()
                );
                throw new Exception(errorMessage);
            }

            if (!message.Equals(expectErrorMessage))
            {
                var errorMessage = string.Join(
                    Environment.NewLine,
                    "",
                    "Query:", result.Query,
                    "Variable:", result.Variable,
                    "Error Messages:", message,
                    "Expect Error Message: ", expectErrorMessage
                );
                throw new Exception(errorMessage);
            }
        }

        private static async Task<ExecuteAsyncResult> ExecuteAsync(
            string queryPath,
            string variablePath = null,
            Action<Position> setPermission = null
        )
        {
            var variable = variablePath == null ? "{}" : File.ReadAllText(variablePath.TrimStart('/'));
            var query = File.ReadAllText(queryPath.TrimStart('/'));

            var User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, Constant.UserName) }
                )
            );

            var position = EmployeeBusiness.Get(Constant.UserName).Position;

            if (setPermission != null) PositionBusiness.UpdateForHelper(setPermission, position);

            var result = await Initializer.DocumentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = Initializer.Schema;
                _.Query = query;
                _.Inputs = JObject.Parse(variable).ToInputs();
                _.UserContext = new GraphQLUserContext { User = User };
                _.ValidationRules = DocumentValidator.CoreRules().Concat(Initializer.ValidationRule).ToList();
            }).ConfigureAwait(false);

            return new ExecuteAsyncResult
            {
                Result = result,
                Query = query,
                Variable = variable
            };
        }

        private class ExecuteAsyncResult
        {
            public string Query;
            public ExecutionResult Result;
            public string Variable;
        }
    }
}
