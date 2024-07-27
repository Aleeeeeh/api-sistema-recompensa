using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using AutoMapper;

namespace api_sistema_recompensas.Profiles;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        CreateMap<CreateRequestDto, Request>();
        CreateMap<RequestAnalysisDto, Request>();
    }
}
