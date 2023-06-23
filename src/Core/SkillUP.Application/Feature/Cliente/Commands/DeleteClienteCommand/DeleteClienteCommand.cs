using MediatR;
using SkillUP.Application.Wrappers;
using SkillUP.Domain.Interfaces.Repositories;

namespace SkillUP.Application.Feature.Cliente.Commands.DeleteClienteCommand;

public class DeleteClienteCommand: IRequest<Response<bool>>
{
    public long Id { get; set; }
}


public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<bool>>
{
    private readonly IClienteRepository clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public async Task<Response<bool>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var result = await clienteRepository.DeleteAsync(request.Id, cancellationToken);
        var response = new Response<bool>
        {
            Success = result,
            Data = result
        };
        return response;
    }
}
