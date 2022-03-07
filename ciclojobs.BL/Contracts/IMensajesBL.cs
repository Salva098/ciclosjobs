using ciclosjobs.Core.DTO.MensajeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IMensajesBL
    {
        void CrearMensaje(MensajeDTOCreate mensajedto);
        List<MensajeDTO> NoLeidosAlumno(int idalumno);
        bool LeerMensaje(int idalumno, int idmensaje);
    }
}
