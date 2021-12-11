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
            CreateMap<AlumnoDTOUpdate, Alumno>();
            CreateMap<Alumno, AlumnoDTOUpdate>();

            CreateMap<AlumnoDTORegistro, Alumno>();
            CreateMap<Alumno, AlumnoDTORegistro>();
            
            CreateMap<AlumnoDTO, Alumno>();
            CreateMap<Alumno, AlumnoDTO>();

            CreateMap<Alumno, AlumnoDTOLogin>();
            CreateMap<AlumnoDTOLogin, Alumno>();


        }
    }
}
