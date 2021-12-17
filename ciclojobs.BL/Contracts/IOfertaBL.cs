using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IOfertaBL
    {
        bool crearOferta(OfertaDTORegistro ofertadto);
        OfertaDTO obtenerOferta(int idoferta);
        List<OfertaDTO> obtenerOfertasempresa(int idempresa);
        List<OfertaDTO> obtenerTodosOferta();
        bool eliminarOferta(OfertaDTORegistro ofertadto);
        bool actualizarOferta(OfertaDTOUpdate ofertadto);
    }
}
