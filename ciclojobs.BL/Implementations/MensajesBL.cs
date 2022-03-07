using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO.MensajeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class MensajesBL : IMensajesBL
    {
        public IMensajesRepository MensajeRepository { get; set; }
        public IMapper mapper { get; set; }

        public MensajesBL(IMensajesRepository MensajeRepository, IMapper mapper)
        {
            this.MensajeRepository = MensajeRepository;
            this.mapper = mapper;
        }
        public void CrearMensaje(MensajeDTOCreate mensajedto)
        {
            MensajeRepository.CrearMensaje(mapper.Map<MensajeDTOCreate, Mensaje>(mensajedto));
        }

        public List<MensajeDTO> NoLeidosAlumno(int idalumno)
        {
            return mapper.Map<List<Mensaje>, List<MensajeDTO>>(MensajeRepository.NoLeidosAlumno(idalumno));
        }

        public bool LeerMensaje(int idalumno, int idmensaje)
        {
            if (MensajeRepository.ExisteMensaje(idalumno, idmensaje))
            {
                Mensaje mensaje = MensajeRepository.getMensaje(idalumno, idmensaje);
                mensaje.leido = true;
                MensajeRepository.LeerMensaje(mensaje);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
