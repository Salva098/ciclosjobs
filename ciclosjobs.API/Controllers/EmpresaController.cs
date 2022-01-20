using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.Security;
using Microsoft.AspNetCore.Authorization;
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

    public class EmpresaController : ControllerBase
    {
        private IEmpresaBL empresaBL;
        public IJwtBearer JwtBearer { get; set; }
        public EmpresaController(IEmpresaBL EmpresaBL, IJwtBearer JwtBearer)
        {
            this.empresaBL = EmpresaBL;
            this.JwtBearer = JwtBearer;
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Register(EmpresaDTORegistro empresadto)
        {
            if (empresaBL.CrearEmpresa(empresadto))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]


        public ActionResult Login(LoginDTO empresadto)
        {
            EmpresaDTO empresa;
            if ((empresa = empresaBL.LoginEmpresa(empresadto))!=null)
            {
                Response.Headers.Add("token", JwtBearer.GenerateJWTTokenEmpresa(empresa));
                return Ok();
            }
            else
            {
                return BadRequest(-1);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmpresaDTO> Get([FromRoute] int id)
        {
            var empresa = empresaBL.ObtenerEmpresa(id);
            if (empresa!=null)
            {
                return Ok(empresa);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public ActionResult<List<EmpresaDTO>> GetAll()
        {
            var empresa = empresaBL.ObtenerTodosEmpresa();
            if (empresa!= null)
            {
                return Ok(empresa);
            }
            else
            {
                return BadRequest();
            }
            
        }



        [HttpDelete]
        public ActionResult Delete(EmpresaDTOUpdate empresadto)
        {
            if (empresaBL.EliminarEmpresa(empresadto))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Update(EmpresaDTOUpdate empresadto)
        {
            int empresaid;
            if ((empresaid = empresaBL.ActualizarEmpresa(empresadto)) != -1)
                return Ok(empresaid);
            else
                return Unauthorized();
        }




    }
}
