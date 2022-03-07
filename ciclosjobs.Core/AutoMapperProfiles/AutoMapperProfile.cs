using AutoMapper;
using ciclojobs.DAL.Entities;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.DTO.CiclosDTO;
using ciclosjobs.Core.DTO.ContractoDTO;
using ciclosjobs.Core.DTO.FacturaDTO;
using ciclosjobs.Core.DTO.FamiliaProfeDTO;
using ciclosjobs.Core.DTO.InscripcionesDTO;
using ciclosjobs.Core.DTO.MensajeDTO;
using ciclosjobs.Core.DTO.ProvinciasDTO;
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

            CreateMap<Provincias,ProvinciasDTO>();
            CreateMap<ProvinciasDTO, Provincias>();

            CreateMap<TipoCiclo, TipoCicloDTO>();
            CreateMap<TipoCicloDTO, TipoCiclo>();

            CreateMap<FamiliaProfe, FamiliaProfeDTO>();
            CreateMap<FamiliaProfeDTO, FamiliaProfe>();

            CreateMap<Inscripciones, InscripcionesDTO>();
            CreateMap<InscripcionesDTO, Inscripciones>();
            
            CreateMap<Inscripciones, InscripcionesDTOCreate>();
            CreateMap<InscripcionesDTOCreate, Inscripciones>();

            CreateMap<Inscripciones, InscripcionesDTOUpdate>();
            CreateMap<InscripcionesDTOUpdate, Inscripciones>();


            CreateMap<Facturas, FacturasDTO>();
            CreateMap<FacturasDTO, Facturas>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();

            CreateMap<Mensaje, MensajeDTO>();
            CreateMap<MensajeDTO, Mensaje>();

            CreateMap<MensajeDTOCreate, Mensaje>();
            CreateMap<Mensaje, MensajeDTOCreate>();


        }
    }
}
