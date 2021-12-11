using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IAlumnoBL
    {
        int Login(AlumnoDTOLogin alumnodto);
        bool CrearAlumno(AlumnoDTORegistro alumnodto);
        AlumnoDTO ObtenerAlumno(int alumnoid);
        List<AlumnoDTO> ObtenerTodosAlumnos();
        bool EliminarAlumno(AlumnoDTOUpdate alumnodto);
        int ActualizarAlumno(AlumnoDTOUpdate alumnodto);
    }
}
