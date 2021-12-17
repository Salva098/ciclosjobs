using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IOfertasRepository
    {
        bool existOfertas(Ofertas ofertas);
        List<Ofertas> obtenerOfertasempresa(int idempresa);
        bool crearOfertas(Ofertas ofertas);
        Ofertas obtenerOfertas(int id);
        List<Ofertas> obtenerTodosOfertas();
        bool eliminarOfertas(int ofertas);
        bool actualizarOfertas(Ofertas ofertas);
    }
}
