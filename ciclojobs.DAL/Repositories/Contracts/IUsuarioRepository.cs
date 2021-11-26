using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(Usuario user);
        Usuario Create(Usuario user);
        bool Exists(Usuario user);
    }
}
