using cqrs_demo.CQRS;
using cqrs_demo.Handlers;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers.Commands;
using cqrs_demo.Services.Customers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IQueryProcessor queryProcessor;

        public ClientsController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor)
        {
            this.commandProcessor = commandProcessor;
            this.queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult GetClients([FromQuery] SearchClientsQuery query)
        {
            var result = queryProcessor.Process<SearchClientsQuery, ICollection<ClientModel>>(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient([FromRoute] Guid id)
        {
            var result = queryProcessor.Process<GetClientByIdQuery, ClientModel>(new GetClientByIdQuery()
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpPost]
        public IActionResult RegisterClient([FromBody] RegisterClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = commandProcessor.Process<RegisterClientCommand, RegisterClientResult>(command);
            Response.StatusCode = StatusCodes.Status201Created;
            return new JsonResult(result);
        }

        [HttpPut("info/{id}")]
        public IActionResult UpdateClientInfo(Guid id, [FromBody] ClientModel model)
        {
            var command = new UpdateClientInfoCommand(id, model.Name, model.Address);
            var result = commandProcessor.Process<UpdateClientInfoCommand, ClientModel>(command);
            return Ok(result);
        }
    }
}
