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
    public class EmpresaBL : IEmpresaBL
    {
        public IMapper mapper { get; set; }
        public IEmpresaRepository EmpresaRepository { get; set; }
        public IPasswordGenerator PasswordGenerator { get; set; }
        public EmpresaBL(IEmpresaRepository EmpresaRepository, IPasswordGenerator PasswordGenerator, IMapper mapper)
        {
            this.EmpresaRepository = EmpresaRepository;
            this.PasswordGenerator = PasswordGenerator;
            this.mapper = mapper;
        }

        public int ActualizarEmpresa(EmpresaDTOUpdate empresadto)
        {
            var empresa = mapper.Map<EmpresaDTOUpdate, Empresa>(empresadto);
            empresa.contrasena = PasswordGenerator.Hash(empresa.contrasena);

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

    }
}