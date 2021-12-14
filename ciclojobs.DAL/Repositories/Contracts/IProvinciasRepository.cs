using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IProvinciasRepository
    {
        Provincias ObtenerProvincia(int id);
        List<Provincias> ObtenerTodoProvincia();

    }
}
