

using SkillUP.Application.DTOs;
using SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;
using SkillUP.Application.Feature.Cliente.Commands.DeleteClienteCommand;
using SkillUP.Application.Feature.Cliente.Commands.UpdateClienteCommand;
using SkillUP.Domain.Entities;
using System.Runtime.CompilerServices;

namespace SkillUP.Application.Externsions;

public static class ExternsionMappers
{
    public static Cliente ToCliente(this CreateClienteCommand createClienteCommand)
    {
        return new Cliente
        {
            Name = createClienteCommand.Name,
            Email = createClienteCommand.Email
        };
    }
    public static CreateClienteCommand ToCommand(this Cliente cliente)
    {
        return new CreateClienteCommand
        {
            Name = cliente.Name,
            Email = cliente.Email,
        };
    }


    public static Cliente ToCliente(this UpdateClienteCommand updateClienteCommand)
    {
        return new Cliente
        {
            Id = updateClienteCommand.Id,
            Name = updateClienteCommand.Name,
            Email = updateClienteCommand.Email 
        };
    }

    public static ClienteDTO ToDTO(this Cliente cliente)
    {
        return new ClienteDTO
        {
            Id = cliente.Id,
            Name = cliente.Name,
            Email = cliente.Email
        };
    }

}
