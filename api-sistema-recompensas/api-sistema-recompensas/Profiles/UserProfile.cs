﻿using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using AutoMapper;

namespace api_sistema_recompensas.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, CreateUserDto>();
        CreateMap<UpdateUserDto, User>();
    }
}
