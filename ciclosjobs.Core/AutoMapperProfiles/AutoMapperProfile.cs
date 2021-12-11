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
            CreateMap<Alumno, AlumnoDTO>();
            CreateMap<AlumnoDTO, Alumno>();

            CreateMap<Ofertas, OfertaDTO>();
            CreateMap<OfertaDTO, Ofertas>();

            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();
        }
    }
}
