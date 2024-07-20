using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using AutoMapper;

namespace api_sistema_recompensas.Profiles;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<TokenDto, Token>();
    }
}
