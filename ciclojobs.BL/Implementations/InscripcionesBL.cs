using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO.InscripcionesDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class InscripcionesBL : IInscripcioneBL
    {
        public IMapper mapper { get; set; }
        public IInscripcionesRepository InscripcionesRepository { get; set; }
        public InscripcionesBL(IInscripcionesRepository InscripcionesRepository, IMapper mapper)
        {
            this.InscripcionesRepository = InscripcionesRepository;
            this.mapper = mapper;
        }
        public int CrearInscripcion(InscripcionesDTOCreate inscripcion)
        {
            return this.InscripcionesRepository.CrearInscripcion(this.mapper.Map<InscripcionesDTOCreate, Inscripciones >(inscripcion));
        }

        public bool DeleteInscripciones(int inscripciones)
        {
            return this.InscripcionesRepository.DeleteInscripciones(inscripciones);
        }

        public List<InscripcionesDTO> GetAllInscripciones()
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetAllInscripciones());
        }

        public InscripcionesDTO GetInscripciones(int id)
        {
            return mapper.Map<Inscripciones, InscripcionesDTO>(InscripcionesRepository.GetInscripciones(id));
        }

        public List<InscripcionesDTO> GetInscripcionesCiclo(int idCiclo)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesCiclo(idCiclo));
        }

        public List<InscripcionesDTO> GetInscripcionesEmpresa(int Empresa)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesEmpresa(Empresa));
        }

        public List<InscripcionesDTO> GetInscripcionesFamilia(int idfamilias)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesFamilia(idfamilias));
        }

        public List<InscripcionesDTO> GetInscripcionesfamiliaTipo(int familia, int idtipo)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesfamiliaTipo(familia,idtipo));

        }

        public List<InscripcionesDTO> GetInscripcionesTipo(int idtipo)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesTipo(idtipo));

        }

        public bool UpdateInscripciones(InscripcionesDTOUpdate inscripciones)
        {
            return InscripcionesRepository.UpdateInscripciones( mapper.Map<InscripcionesDTOUpdate, Inscripciones>(inscripciones)) ;

        }

        public int Checkinscripcion(int idAlumno, int idOferta)
        {
            return InscripcionesRepository.Checkinscripcion(idAlumno, idOferta);
        }

        public List<InscripcionesDTO> GetInscripcionesAlumno(int id)
        {
            return mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(InscripcionesRepository.GetInscripcionesAlumno(id));

        }
    }
}
