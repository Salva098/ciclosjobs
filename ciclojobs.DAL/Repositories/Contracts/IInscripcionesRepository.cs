using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IInscripcionesRepository
    {
        public int CrearInscripcion(Inscripciones inscripcion);
        public Inscripciones GetInscripciones(int id);
        public List<Inscripciones> GetAllInscripciones();
        public bool DeleteInscripciones(int inscripciones);
        public bool UpdateInscripciones(Inscripciones inscripciones);

        public List<Inscripciones> GetInscripcionesFamilia(int idfamilias);
        public List<Inscripciones> GetInscripcionesTipo(int idtipo);
        public List<Inscripciones> GetInscripcionesfamiliaTipo(int familia,int idtipo);
        public List<Inscripciones> GetInscripcionesCiclo(int idCiclo);
        public List<Inscripciones> GetInscripcionesEmpresa(int Empresa);
        public int Checkinscripcion(int idAlumno, int idOferta);
        public List<Inscripciones> GetInscripcionesAlumno(int id);
    }
}
