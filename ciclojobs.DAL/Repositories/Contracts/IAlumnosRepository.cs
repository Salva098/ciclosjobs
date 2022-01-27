using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IAlumnosRepository
    {
        Alumno BuscaPorEmail(string Alumno);
        bool Login(Alumno alumno);
        bool ExistAlumnos(Alumno alumno);
        Alumno CrearAlumnos(Alumno alumno);
        Alumno ObtenerAlumno(int alumnoid);
        List<Alumno> ObtenerTodosAlumnos();
        bool EliminarAlumno(Alumno alumno);
        Alumno ActualizarAlumno(Alumno alumno);
        bool VerificarCode(string email, string code);
        bool VerificarCode(string email);
    }
}
