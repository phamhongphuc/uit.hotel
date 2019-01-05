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
            object variable = null,
            Action<Position> setPermission = null
        )
        {
            var result = ExecuteAsync(queryPath, variable, setPermission).GetAwaiter().GetResult();
            var jsonResult = getJsonResultOrThrow(result);
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

        private static JObject getJsonResultOrThrow(ExecuteAsyncResult result)
        {
            var jsonResult = JObject.Parse(
                            JsonConvert.SerializeObject(
                                new { data = result.Result.Data }
                            )
                        );
            if (result.Result.Errors != null)
            {
                Exception error = result.Result.Errors[0];
                var message = "";
                while (error != null)
                {
                    message = error.Message;
                    error = error.InnerException;
                }
                var errorMessage = string.Join(
                    Environment.NewLine,
                    "",
                    "Query:", result.Query,
                    "Variable:", result.Variable,
                    "Result:", jsonResult.ToString(),
                    "Error Messages:", message
                );
                throw new Exception(errorMessage, new Exception(message));
            }

            return jsonResult;
        }

        public static void ExecuteAndExpectError(
            string expectErrorMessage,
            string queryPath,
            object variable = null,
            Action<Position> setPermission = null
        )
        {
            var result = ExecuteAsync(queryPath, variable, setPermission).GetAwaiter().GetResult();
            try
            {
                getJsonResultOrThrow(result);
            }
            catch (Exception error)
            {
                if (error.InnerException == null) throw error;
                var message = error.InnerException.Message;
                if (!message.Equals(expectErrorMessage))
                {
                    throw error;
                }
            }
        }

        private static async Task<ExecuteAsyncResult> ExecuteAsync(
            string queryPath,
            object variableObject = null,
            Action<Position> setPermission = null
        )
        {
            string variable = "{}";
            if (variableObject is string)
            {
                variable = File.ReadAllText(((string)variableObject).TrimStart('/'));
            }
            else if (variableObject != null)
            {
                variable = JsonConvert.SerializeObject(variableObject);
            }
            var query = File.ReadAllText(queryPath.TrimStart('/'));

            var User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, Constant.adminName) }
                )
            );

            var position = EmployeeBusiness.Get(Constant.adminName).Position;

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
