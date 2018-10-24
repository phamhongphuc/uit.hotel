using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using uit.ooad.GraphQL;

namespace uit.ooad.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        public readonly DataLoaderDocumentListener _listener;
        private readonly ISchema _schema;
        private readonly IEnumerable<IValidationRule> _validationRules;

        public GraphQLController(
            IDocumentExecuter documentExecuter,
            IEnumerable<IValidationRule> validationRules,
            ISchema schema,
            IServiceProvider serviceProvider
        )
        {
            _documentExecuter = documentExecuter;
            _listener = serviceProvider.GetRequiredService<DataLoaderDocumentListener>();
            _schema = schema;
            _validationRules = validationRules;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLParameter parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = parameter.Query,
                Inputs = parameter.Variables.ToInputs(),
                OperationName = parameter.OperationName,
                UserContext = new GraphQLUserContext { User = User },
                ValidationRules = DocumentValidator.CoreRules().Concat(_validationRules).ToList()
            };
            executionOptions.Listeners.Add(_listener);

            var result = await _documentExecuter
                              .ExecuteAsync(executionOptions)
                              .ConfigureAwait(false);

            if (result.Errors?.Count > 0) return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
