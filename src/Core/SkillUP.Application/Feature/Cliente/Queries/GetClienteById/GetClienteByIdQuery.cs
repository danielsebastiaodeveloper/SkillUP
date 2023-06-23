
using AutoMapper;
using MediatR;
using SkillUP.Application.DTOs;
using SkillUP.Application.Externsions;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Queries.GetClienteById;

public class GetClienteByIdQuery : IRequest<Response<ClienteDTO>>
{
    public long Id { get; set; }
}

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Response<ClienteDTO>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }
    public async Task<Response<ClienteDTO>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await clienteRepository.GetEntityByIdAsync(request.Id, cancellationToken);

        //var dto = result.ToDTO();
        var dto = mapper.Map<ClienteDTO>(result);
        return new Response<ClienteDTO> { 
            Success = true,
            Data = dto
        };
    }
}
