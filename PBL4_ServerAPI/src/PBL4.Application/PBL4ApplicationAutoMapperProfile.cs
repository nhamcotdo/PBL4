﻿using AutoMapper;
using PBL4.UserLogins;
using PBL4.UserLogins.Dtos;

namespace PBL4;

public class PBL4ApplicationAutoMapperProfile : Profile
{
    public PBL4ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
         
         CreateMap<CreateUpdateUserLoginDto,UserLogin>();
         CreateMap<UserLoginDto,UserLogin>();
         CreateMap<UserLogin,UserLoginDto>();
         CreateMap<CreateUpdateUserLoginDto,UserLoginDto>();
         CreateMap<UserLoginDto,CreateUpdateUserLoginDto>();
    }
}
