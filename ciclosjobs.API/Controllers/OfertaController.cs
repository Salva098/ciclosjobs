using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
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

    public class OfertaController : ControllerBase
    {

        public IOfertaBL ofertaBL { get; set; }
        public IJwtBearer JwtBearer { get; set; }
        public OfertaController(IOfertaBL ofertaBL, IJwtBearer JwtBearer)
        {
            this.ofertaBL = ofertaBL;
            this.JwtBearer = JwtBearer;
        }

        [HttpPost]
        public ActionResult CrearOferta(OfertaDTORegistro ofertadto)
        {
            int empresaid = JwtBearer.GetEmpresaIdFromToken(Request.Headers["Authorization"].ToString());
            ofertadto.idempresas = empresaid;
            if (ofertaBL.crearOferta(ofertadto))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("NoCaducado/{id}")]

        public ActionResult<List<OfertaDTO>> getOfertasNoCaducadas([FromRoute] int id)
        {
            var lista = ofertaBL.getOfertasNoCaducadas(id);
            if (lista.Count >= 1)
            {
                return Ok(lista);

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public ActionResult<List<OfertaDTO>> getAll()
        {
            var lista = ofertaBL.obtenerTodosOferta();
            if (lista.Count >= 1)
            {
            return Ok(lista);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Empresa")]
        public ActionResult<List<OfertaDTO>> GetofertasEmpresa()
        {
            int empresaid = JwtBearer.GetEmpresaIdFromToken(Request.Headers["Authorization"].ToString());

            var lista = ofertaBL.obtenerOfertasempresa(empresaid);
            if (lista.Count >= 1)
            {
                return Ok(lista);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public OfertaDTO getOferta([FromRoute] int id)
        {
            return ofertaBL.obtenerOferta(id);
        }

        [HttpPut]
        public ActionResult Actualizar(OfertaDTOUpdate ofertadto)
        {
            if (ofertaBL.actualizarOferta(ofertadto))
            {
            return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Ciclo/{id}")]
        public List<OfertaDTO> ObtenerOfertasCiclos([FromRoute] int id)
        {
            return ofertaBL.ObtenerOfertasCiclos(id);
        }

        
        [HttpDelete]
        public ActionResult Eliminar(OfertaDTOUpdate ofertadto)
        {
            if (ofertaBL.eliminarOferta(ofertadto))
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
