using ciclosjobs.Core.DTO.InscripcionesDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IInscripcioneBL
    {
        public int CrearInscripcion(InscripcionesDTOCreate inscripcion);
        public InscripcionesDTO GetInscripciones(int id);
        public List<InscripcionesDTO> GetAllInscripciones();
        public bool DeleteInscripciones(InscripcionesDTOUpdate inscripciones);
        public bool UpdateInscripciones(InscripcionesDTOUpdate inscripciones);

        public List<InscripcionesDTO> GetInscripcionesFamilia(int idfamilias);
        public List<InscripcionesDTO> GetInscripcionesTipo(int idtipo);
        public List<InscripcionesDTO> GetInscripcionesfamiliaTipo(int familia, int idtipo);
        public List<InscripcionesDTO> GetInscripcionesCiclo(int idCiclo);
        public List<InscripcionesDTO> GetInscripcionesEmpresa(int Empresa);

    }
}
