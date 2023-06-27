using AutoMapper;
using MediatR;
using SkillUP.Application.DTOs;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Queries.GetAllCliente;

public class GetAllClientesQuery: IRequest<Response<IEnumerable<ClienteDTO>>>
{
    public bool State { get; set; } = true;
}

public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, Response<IEnumerable<ClienteDTO>>>
{
    private readonly IClienteRepository clienteRepository;
    private readonly IMapper mapper;

    public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }
    public async Task<Response<IEnumerable<ClienteDTO>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
    {
        var param = new { @State = request.State };
        var result = await clienteRepository.GetAllEntitiesAsync(param, cancellationToken);
        var clientes = mapper.Map<List<ClienteDTO>>(result);
        var response = new Response<IEnumerable<ClienteDTO>>(clientes, "Success");
        return response;
    }
}
