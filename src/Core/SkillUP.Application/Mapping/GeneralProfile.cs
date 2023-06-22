
using AutoMapper;
using SkillUP.Application.DTOs;
using SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;
using SkillUP.Application.Feature.Cliente.Commands.UpdateClienteCommand;
using SkillUP.Domain.Entities;

namespace SkillUP.Application.Mapping;

public class GeneralProfile: Profile
{
    public GeneralProfile()
    {
        #region Commandos
        CreateMap<Cliente, CreateClienteCommand>().ReverseMap();
        CreateMap<Cliente, UpdateClienteCommand>().ReverseMap();
        #endregion

        #region Queries

        #endregion

        #region DTOs

        CreateMap<Cliente, ClienteDTO>().ReverseMap();

        #endregion
    }
}
