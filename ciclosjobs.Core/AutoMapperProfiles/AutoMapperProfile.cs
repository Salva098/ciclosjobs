﻿using AutoMapper;
using ciclojobs.DAL.Entities;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.DTO.CiclosDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.AutoMapperProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlumnoDTOUpdate, Alumno>();
            CreateMap<Alumno, AlumnoDTOUpdate>();

            CreateMap<AlumnoDTORegistro, Alumno>();
            CreateMap<Alumno, AlumnoDTORegistro>();
            
            CreateMap<AlumnoDTO, Alumno>();
            CreateMap<Alumno, AlumnoDTO>();

            CreateMap<Alumno, LoginDTO>();
            CreateMap<LoginDTO, Alumno>();

            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();

            CreateMap<Empresa, EmpresaDTORegistro>();
            CreateMap<EmpresaDTORegistro, Empresa>();

            CreateMap<Empresa, LoginDTO>();
            CreateMap<LoginDTO, Empresa>();

            CreateMap<Empresa, EmpresaDTOUpdate>();
            CreateMap<EmpresaDTOUpdate, Empresa>();


            CreateMap<Ofertas, OfertaDTO>();
            CreateMap<OfertaDTO, Ofertas>();

            CreateMap<Ofertas, OfertaDTORegistro>();
            CreateMap<OfertaDTORegistro, Ofertas>();

            CreateMap<Ofertas, OfertaDTOUpdate>();
            CreateMap<OfertaDTOUpdate, Ofertas>();

            CreateMap<Ciclo, CicloDTORegister>();
            CreateMap<CicloDTORegister, Ciclo>();

            CreateMap<Ciclo, CicloDTO>();
            CreateMap<CicloDTO, Ciclo>();




        }
    }
}
