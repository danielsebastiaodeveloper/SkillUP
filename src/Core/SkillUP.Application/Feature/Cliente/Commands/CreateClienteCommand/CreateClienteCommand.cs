using AutoMapper;
using MediatR;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;

public class CreateClienteCommand : IRequest<Response<Guid>>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}


public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<Guid>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }

    public async Task<Response<Guid>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = mapper.Map<Domain.Entities.Cliente>(request);
        var result = await clienteRepository.CreateAsync(cliente, cancellationToken);
        
        var response = new Response<Guid>()
        {
            Data = result,
            Success = true   
        };
        return response;
    }
}



