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
        public ActionResult<EmpresaDTO> Register(EmpresaDTORegistro empresadto)
        {
            EmpresaDTO emrpesa = null;
            if ((emrpesa=empresaBL.CrearEmpresa(empresadto))!=null)
            {
                return Ok(emrpesa);
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
                var a = JwtBearer.GenerateJWTTokenEmpresa(empresa);
                Response.Headers.Add("token",a);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("ID")]
        public ActionResult<EmpresaDTO> Get()
        {

            var empresa = empresaBL.ObtenerEmpresa(JwtBearer.GetEmpresaIdFromToken(Request.Headers["Authorization"].ToString()));
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

        [HttpGet]
        [Route("EmailEmpresa")]
        [AllowAnonymous]

        public ActionResult<EmpresaDTO> GetEmpresaEmail(string email)
        {
            EmpresaDTO empresa = empresaBL.GetEmpresaEmail(email);
            if (empresa != null)
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
        [AllowAnonymous]
        public ActionResult Update(EmpresaDTOUpdate empresadto)
        {
            int empresaid;
            if ((empresaid = empresaBL.ActualizarEmpresa(empresadto)) != -1)
                return Ok(empresaid);
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GenerarCode")]
        [AllowAnonymous]
        public ActionResult GenerarCode(String email)
        {
            if (empresaBL.GenerarCode(email))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("CheckAccount")]
        [AllowAnonymous]
        public ActionResult CheckAccount(String email)
        {
            if (empresaBL.CheckAccount(email))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("VerificarCode")]
        [AllowAnonymous]
        public ActionResult VerificarCode(String email, string code)
        {
            if (empresaBL.VerificarCode(email, code))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("SendEmail")]
        
        public ActionResult SendEmail(string emailalumno, string tituloOferta, string mensaje)
        {
            var empresa = empresaBL.ObtenerEmpresa(JwtBearer.GetEmpresaIdFromToken(Request.Headers["Authorization"].ToString()));

            empresaBL.SendEmail(emailalumno, empresa.id, tituloOferta, mensaje);
            return Ok();

        }
        [HttpPost]
        [Route("VerificarAccount")]
        [AllowAnonymous]
        public ActionResult VerificarAccount(String email, string code)
        {
            if (empresaBL.VerificarAccount(email, code))
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
