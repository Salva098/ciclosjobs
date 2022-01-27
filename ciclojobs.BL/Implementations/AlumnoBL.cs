﻿using AutoMapper;
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
