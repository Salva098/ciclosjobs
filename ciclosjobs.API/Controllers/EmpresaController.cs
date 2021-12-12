using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ciclosjobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private IEmpresaBL empresaBL;
        public EmpresaController(IEmpresaBL EmpresaBL)
        {
            this.empresaBL = EmpresaBL;
        }
        [HttpPost]
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

        public ActionResult<int> Login(EmpresaDTOLogin empresadto)
        {
            int id;
            if ((id=empresaBL.LoginEmpresa(empresadto))!=-1)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(-1);
            }
        }
        [HttpGet]
        public ActionResult<EmpresaDTO> Get(int id)
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
        [Route("getAllEmpresa")]
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
