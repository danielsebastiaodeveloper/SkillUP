using AutoMapper;
using MediatR;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Interfaces;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;

public class CreateClienteCommand : IRequest<Response<long>>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}


public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<long>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;
    private readonly IDateTimeService dateTimeService;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, IDateTimeService dateTimeService )
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
        this.dateTimeService = dateTimeService;
    }

    public async Task<Response<long>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = mapper.Map<Domain.Entities.Cliente>(request);
        cliente.CreatedAt  = dateTimeService.NowUtc;
        //TODO: Create a userService to get user authenticated data.
        cliente.CreatedBy = 1;
        var result = await clienteRepository.CreateAsync(cliente, cancellationToken);
        
        var response = new Response<long>()
        {
            Data = result,
            Success = true   
        };
        return response;
    }
}



