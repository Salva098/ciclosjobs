using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IEmpresaRepository
    {
        bool ExistEmpresa(Empresa empresa);
        bool CrearEmpresa(Empresa empresa);

        bool LoginEmpresa(Empresa empresa);
        Empresa ObtenerEmpresa(int id);

        Empresa ObtenerPorEmail(String Email);
        List<Empresa> ObtenerTodosEmpresa();
        bool EliminarEmpresa(Empresa empresa);
        Empresa ActualizarEmpresa(Empresa empresa);
        Empresa BuscaPorEmail(string email);
        bool VerificarCode(string email, string code);
        bool CheckAccount(string email);
    }
}
