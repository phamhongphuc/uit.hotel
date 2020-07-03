﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using uit.hotel.GraphQLHelper;

namespace uit.hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly DataLoaderDocumentListener _listener;
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
        public async Task<IActionResult> Post([FromBody] System.Text.Json.JsonElement rawQuery)
        {
            string rawJson = rawQuery.ToString();
            var parameter = JsonConvert.DeserializeObject<GraphQLParameter>(rawJson);

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
