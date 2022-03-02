using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IContratoRepository
    {
        bool ExistContract(Contrato contrato);
        void CrearContrato(Contrato contrato);
    }
}
