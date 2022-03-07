using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IMensajesRepository
    {
        void CrearMensaje(Mensaje mensaje);
        List<Mensaje> NoLeidosAlumno(int idalumno);
        bool ExisteMensaje(int idalumno, int idmensaje);

        Mensaje getMensaje(int idalumno, int idmensaje);
        void LeerMensaje(Mensaje mensaje);
    }
}
