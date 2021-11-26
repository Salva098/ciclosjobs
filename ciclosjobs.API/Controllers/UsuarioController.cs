using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
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
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBL usuarioBL { get; set; }
        public UsuarioController(IUsuarioBL usuarioBL)
        {
            this.usuarioBL= usuarioBL;
        }
            

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO is null)
            {
                return BadRequest();
            }

            if (usuarioBL.Login(usuarioDTO))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }
        [HttpPost]
        public ActionResult<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {
            var user = usuarioBL.Create(usuarioDTO);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();

            }

        }
    }
}
