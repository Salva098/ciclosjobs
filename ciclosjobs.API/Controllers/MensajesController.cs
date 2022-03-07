using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO.MensajeDTO;
using ciclosjobs.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ciclosjobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MensajesController : ControllerBase
    {
        private IMensajesBL MensajesBL;
        public IJwtBearer JwtBearer;

        public MensajesController(IMensajesBL MensajesBL, IJwtBearer JwtBearer)
        {
            this.MensajesBL = MensajesBL;
            this.JwtBearer = JwtBearer;
        }

        [HttpPost]
        public ActionResult CreaMensaje(MensajeDTOCreate empresadto)
        {
            empresadto.empresaid = JwtBearer.GetEmpresaIdFromToken(Request.Headers["Authorization"].ToString());
            MensajesBL.CrearMensaje(empresadto);
            return Ok();
        }

        [HttpGet]
        [Route("NoLeidos")]
        public ActionResult<List<MensajeDTO>> NoLeidosAlumno()
        {
            var idalumno= JwtBearer.GetAlumnoIdFromToken(Request.Headers["Authorization"].ToString());

            return Ok(MensajesBL.NoLeidosAlumno(idalumno));
        }

        [HttpPost]
        [Route("LeerMensaje")]
        public ActionResult<List<MensajeDTO>> LeerMensaje(int idmensaje)
        {
            var idalumno = JwtBearer.GetAlumnoIdFromToken(Request.Headers["Authorization"].ToString());
            if (MensajesBL.LeerMensaje(idalumno,idmensaje))
            {

            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
