using AutoMapper;
using MediatR;
using SkillUP.Application.Externsions;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Entities;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Commands.UpdateClienteCommand;

public class UpdateClienteCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}


public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<bool>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }

    public async Task<Response<bool>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        //var cliente = request.ToCliente();
        var cliente = mapper.Map<Domain.Entities.Cliente>(request);
        var result = await clienteRepository.UpdateAsync(cliente, cliente.Id, cancellationToken);
        var response = new Response<bool>
        {
            Success = result,
            Data = result
        };
        return response;
    }
}