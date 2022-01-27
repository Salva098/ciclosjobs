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
    public class EmpresaBL : IEmpresaBL
    {
        public IMapper mapper { get; set; }
        public IEmpresaRepository EmpresaRepository { get; set; }
        public IPasswordGenerator PasswordGenerator { get; set; }
        public IEmailSender EmailSender { get; set; }
        public EmpresaBL(IEmpresaRepository EmpresaRepository, IPasswordGenerator PasswordGenerator, IMapper mapper, IEmailSender EmailSender)
        {
            this.EmpresaRepository = EmpresaRepository;
            this.PasswordGenerator = PasswordGenerator;
            this.mapper = mapper;
            this.EmailSender = EmailSender;
        }

        public int ActualizarEmpresa(EmpresaDTOUpdate empresadto)
        {
            var empresa = mapper.Map<EmpresaDTOUpdate, Empresa>(empresadto);
                empresa.contrasena = PasswordGenerator.Hash(empresa.contrasena);
            empresa.verificado = EmpresaRepository.CheckAccount(empresa.email);
            if (this.EmpresaRepository.ExistEmpresa(empresa))
            {
           

           
                return this.EmpresaRepository.ActualizarEmpresa(empresa).id;
            }
            else
            {
                return -1;
            }
        }

        public bool CrearEmpresa(EmpresaDTORegistro empresadto)
        {
            var empresa = mapper.Map<EmpresaDTORegistro, Empresa>(empresadto);
            empresa.contrasena = PasswordGenerator.Hash(empresa.contrasena);
            if (!this.EmpresaRepository.ExistEmpresa(empresa))
            {
                return EmpresaRepository.CrearEmpresa(empresa);
            }
            else
            {
                return false;
            }
        }

        public EmpresaDTO ObtenerEmpresa(int empresaid)
        {
            return mapper.Map<Empresa, EmpresaDTO>(this.EmpresaRepository.ObtenerEmpresa(empresaid));
        }

        public List<EmpresaDTO> ObtenerTodosEmpresa()
        {
            return mapper.Map<List<Empresa>, List<EmpresaDTO>>(this.EmpresaRepository.ObtenerTodosEmpresa());
        }

        public bool EliminarEmpresa(EmpresaDTOUpdate empresadto)
        {
            var empresa = mapper.Map<EmpresaDTOUpdate, Empresa>(empresadto);
            empresa.contrasena = PasswordGenerator.Hash(empresa.contrasena);

            if (this.EmpresaRepository.ExistEmpresa(empresa))
            {
                return this.EmpresaRepository.EliminarEmpresa(empresa);
            }
            else
            {
                return false;
            }
        }

        public EmpresaDTO LoginEmpresa(LoginDTO empresadto)
        {
            var empresa = mapper.Map<LoginDTO, Empresa>(empresadto);
            empresa.contrasena = PasswordGenerator.Hash(empresa.contrasena);

            if (this.EmpresaRepository.LoginEmpresa(empresa))
            {
                return mapper.Map<Empresa, EmpresaDTO> (EmpresaRepository.ObtenerPorEmail(empresa.email));
            }
            else
            {
                return null;
            }
            

        }

        public bool GenerarCode(string email)
        {
            Empresa empresa = EmpresaRepository.BuscaPorEmail(email);
            if (empresa != null)
            {
                Random r = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    int numero = r.Next(10);
                    code = code + numero.ToString();
                }
                empresa.codeverify = code;
                EmpresaRepository.ActualizarEmpresa(empresa);
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
            return EmpresaRepository.VerificarCode(email, code);
        }

        public EmpresaDTO GetEmpresaEmail(string email)
        {
            Empresa empresa = EmpresaRepository.BuscaPorEmail(email);
            if (empresa!=null)
            {
                return mapper.Map<Empresa, EmpresaDTO>(EmpresaRepository.ObtenerPorEmail(empresa.email));
            }
            else
            {
                return null;
            }
        }

        public bool CheckAccount(string email)
        {
            return EmpresaRepository.CheckAccount(email);
        }

        public bool VerificarAccount(string email, string code)
        {
            if (EmpresaRepository.VerificarCode(email, code))
            {
                var empresa = EmpresaRepository.BuscaPorEmail(email);
                empresa.verificado = true;
                EmpresaRepository.ActualizarEmpresa(empresa);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendEmail(string emailalumno, int idempresa, string tituloOferta, string mensaje)
        {
            String nombreempresa = EmpresaRepository.ObtenerEmpresa(idempresa).nombre;
            EmailSender.SendEmail(emailalumno, nombreempresa, tituloOferta, mensaje);
        }
    }
}