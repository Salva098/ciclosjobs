using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class AlumnoBL : IAlumnoBL
    {
        public IMapper mapper { get; set; }
        public IAlumnosRepository AlumnosRepository { get; set; }
        public IPasswordGenerator PasswordGenerator { get; set; }
        public AlumnoBL(IAlumnosRepository AlumnosRepository, IPasswordGenerator PasswordGenerator, IMapper mapper)
        {
            this.AlumnosRepository = AlumnosRepository;
            this.PasswordGenerator = PasswordGenerator;
            this.mapper = mapper;
        }

        public bool CrearAlumno(AlumnoDTORegistro alumnodto)
        {
            var alumno = mapper.Map<AlumnoDTORegistro, Alumno>(alumnodto);
            alumno.contrasena = PasswordGenerator.Hash(alumno.contrasena);
            if (!this.AlumnosRepository.ExistAlumnos(alumno))
            {
                 this.AlumnosRepository.CrearAlumnos(alumno);
                return true;
            }
            else
            {
                return false;
            }

        }

        public AlumnoDTO ObtenerAlumno(int alumnoid)
        {
            return mapper.Map<Alumno, AlumnoDTO>(this.AlumnosRepository.ObtenerAlumno(alumnoid));
        }

        public List<AlumnoDTO> ObtenerTodosAlumnos()
        {
            return mapper.Map<List<Alumno>, List<AlumnoDTO>>(this.AlumnosRepository.ObtenerTodosAlumnos());
        }

        public bool EliminarAlumno(AlumnoDTOUpdate alumnodto)
        {
            var alumno = mapper.Map<AlumnoDTOUpdate, Alumno>(alumnodto);
            if (this.AlumnosRepository.ExistAlumnos(alumno))
            {
                return this.AlumnosRepository.EliminarAlumno(alumno);
            }
            else
            {
                return false;
            }
        }

        public int ActualizarAlumno(AlumnoDTOUpdate alumnodto)
        {

            var alumno = mapper.Map<AlumnoDTOUpdate, Alumno>(alumnodto);
            alumno.contrasena = PasswordGenerator.Hash(alumno.contrasena);

            if (this.AlumnosRepository.ExistAlumnos(alumno))
            {
                if (alumno.email == null)
                {
                    return -1;
                }
                return this.AlumnosRepository.ActualizarAlumno(alumno).id;
            }
            else
            {
                return -1;
            }
        }

        public AlumnoDTO Login(LoginDTO alumnodto)
        {
            var alumno = mapper.Map<LoginDTO, Alumno>(alumnodto);
            alumno.contrasena = PasswordGenerator.Hash(alumno.contrasena);
            if (this.AlumnosRepository.Login(alumno))
            {

            return mapper.Map<Alumno, AlumnoDTO>(this.AlumnosRepository.BuscaPorEmail(alumno));
            }
            else
            {
                return null;
            }
        }

      

       
    }
}
