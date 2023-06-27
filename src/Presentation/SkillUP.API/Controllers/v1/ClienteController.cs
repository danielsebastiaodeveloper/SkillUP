using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;
using SkillUP.Application.Feature.Cliente.Commands.DeleteClienteCommand;
using SkillUP.Application.Feature.Cliente.Commands.UpdateClienteCommand;
using SkillUP.Application.Feature.Cliente.Queries.GetAllCliente;
using SkillUP.Application.Feature.Cliente.Queries.GetClienteById;

namespace SkillUP.API.Controllers.v1;

[ApiVersion("1.0")]
public class ClienteController : BaseApiController
{
    private readonly IMediator mediator;

    public ClienteController(IMediator mediator): base()
    {
        this.mediator = mediator;
    }

    //GET, POST, PUT, PATCH, DELETE

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllClientesQuery getAllClientesQuery, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(getAllClientesQuery, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{Id}", Name = "GetClienteById")]
    //http://localhost:32512/api/v1/clientes/1
    public async Task<IActionResult> GetClienteById(long Id, CancellationToken cancellationToken)
    {
        var cliente = new GetClienteByIdQuery
        {
            Id = Id
        };
        var result = await mediator.Send(cliente, cancellationToken);

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Post(CreateClienteCommand clienteCommand, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(clienteCommand, cancellationToken);
        return CreatedAtRoute("GetClienteById", new { Id = result.Data }, null);
    }

    [HttpPut("{Id}")]
    //http://localhost:32512/api/v1/clientes/1
    public async Task<IActionResult> Put(long Id, [FromBody] UpdateClienteCommand updateClienteCommand, CancellationToken cancellationToken)
    {
        // TODO: Move the validation to Filter
        if (Id != updateClienteCommand.Id)
        {
            return BadRequest("The Id param is not valid.");
        }

        var result = await mediator.Send(updateClienteCommand, cancellationToken);

        if (result.Data)
        {
            return NoContent();
        }

        return BadRequest(result);
    }

    [HttpDelete("{Id}")]
    //http://localhost:32512/api/v1/clientes/1
    public async Task<IActionResult> Delete(long Id, CancellationToken cancellationToken)
    {
        var cliente = new DeleteClienteCommand
        {
            Id = Id
        };

        var result = await mediator.Send(cliente, cancellationToken);

        if (result.Data)
        {
            return NoContent();
        }

        return BadRequest(result);
    }

}
