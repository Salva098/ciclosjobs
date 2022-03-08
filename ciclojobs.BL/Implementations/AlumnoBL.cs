using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.Security;
using ciclosjobs.Core.Security.EmailSender;
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
        public IEmailSender EmailSender { get; set; }
        public AlumnoBL(IAlumnosRepository AlumnosRepository, IPasswordGenerator PasswordGenerator, IMapper mapper,IEmailSender EmailSender)
        {
            this.AlumnosRepository = AlumnosRepository;
            this.PasswordGenerator = PasswordGenerator;
            this.mapper = mapper;
            this.EmailSender = EmailSender;
        }

        public bool CrearAlumno(AlumnoDTORegistro alumnodto)
        {
            var alumno = mapper.Map<AlumnoDTORegistro, Alumno>(alumnodto);
            alumno.foto = "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";
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
            var a = AlumnosRepository.BuscaPorEmail(alumnodto.email);
            
            if (alumnodto.id==0 && a != null)
            {
                alumnodto.id = a.id;

            }

            var alumno = mapper.Map<AlumnoDTOUpdate, Alumno>(alumnodto);
            alumno.contrasena = PasswordGenerator.Hash(alumno.contrasena);
            alumno.verificado = a.verificado;
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

            return mapper.Map<Alumno, AlumnoDTO>(this.AlumnosRepository.BuscaPorEmail(alumno.email));
            }
            else
            {
                return null;
            }
        }

        public bool GenerarCode(string email)
        {
            Alumno alumno = AlumnosRepository.BuscaPorEmail(email);
            if (alumno != null)
            {
                Random r = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    int numero = r.Next(10);
                    code = code + numero.ToString();
                }
                alumno.codeverify = code;
                AlumnosRepository.ActualizarAlumno(alumno);
                EmailSender.Send(email, code);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCode(string email, string code)
        {
            return AlumnosRepository.VerificarCode(email, code);
        }

        public AlumnoDTO GetAlumnoEmail(string email)
        {
            return mapper.Map<Alumno, AlumnoDTO>(this.AlumnosRepository.BuscaPorEmail(email));
        }

        public bool VerificarAccount(string email, string code)
        {
            if (AlumnosRepository.VerificarCode(email, code))
            {
                var alumno = AlumnosRepository.BuscaPorEmail(email);
                alumno.verificado = true;
                AlumnosRepository.ActualizarAlumno(alumno);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCode(string email)
        {
            return AlumnosRepository.VerificarCode(email);
        }
    }
}
