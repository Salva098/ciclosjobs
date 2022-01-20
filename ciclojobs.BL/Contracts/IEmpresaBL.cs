
using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IEmpresaBL
    {
        bool CrearEmpresa(EmpresaDTORegistro empresadto);
        EmpresaDTO LoginEmpresa(LoginDTO empresa);
        EmpresaDTO ObtenerEmpresa(int empresaid);
        List<EmpresaDTO> ObtenerTodosEmpresa();
        bool EliminarEmpresa(EmpresaDTOUpdate empresadto);
        int ActualizarEmpresa(EmpresaDTOUpdate empresadto);

    }
}
