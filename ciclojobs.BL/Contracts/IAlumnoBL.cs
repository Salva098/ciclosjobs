using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IAlumnoBL
    {
        AlumnoDTO Login(LoginDTO alumnodto);
        bool CrearAlumno(AlumnoDTORegistro alumnodto);
        AlumnoDTO ObtenerAlumno(int alumnoid);
        List<AlumnoDTO> ObtenerTodosAlumnos();
        bool EliminarAlumno(AlumnoDTOUpdate alumnodto);
        int ActualizarAlumno(AlumnoDTOUpdate alumnodto);
        bool GenerarCode(string email);
        bool VerificarCode(string email, string code);
        AlumnoDTO GetAlumnoEmail(string email);
        bool VerificarAccount(string email, string code);
        bool VerificarCode(string email);
    }
}
