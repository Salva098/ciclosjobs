using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using ciclojobs.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using ciclosjobs.Core.Security;
using AutoMapper;

namespace ciclojobs.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IMapper mapper { get; set; }
        public IUsuarioRepository UsurioRepository { get; set; }
        public IPasswordGenerator PasswordGenerator { get; set; }
        public UsuarioBL(IUsuarioRepository UsurioRepository, IPasswordGenerator PasswordGenerator, IMapper mapper)
        {
            this.UsurioRepository = UsurioRepository;
            this.PasswordGenerator = PasswordGenerator;
            this.mapper = mapper;
        }

        public bool Login(UsuarioDTO usuario)
        {
            var Usuario = mapper.Map<UsuarioDTO, Usuario>(usuario);
            return UsurioRepository.Login(Usuario);
        }

        public UsuarioDTO Create(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Password = PasswordGenerator.Hash(usuarioDTO.Password);
            var Usuario = mapper.Map<UsuarioDTO, Usuario>(usuarioDTO); ;

            if (!UsurioRepository.Exists(Usuario))
            {
                var usuario =UsurioRepository.Create(Usuario);
                return mapper.Map<Usuario, UsuarioDTO>(usuario);
            }
            return null;
        }
    }
}
