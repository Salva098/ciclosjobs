using AutoMapper;
using ciclojobs.DAL.Entities;
using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.AutoMapperProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
