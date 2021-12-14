using ciclosjobs.Core.DTO.ProvinciasDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IProvinciasBL
    {
        ProvinciasDTO ObtenerProvincia(int id);
        List<ProvinciasDTO> ObtenerTodoProvincia();
       
    }
}
