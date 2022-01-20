using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
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
        public OfertaController(IOfertaBL ofertaBL)
        {
            this.ofertaBL = ofertaBL;
        }

        [HttpPost]
        public ActionResult CrearOferta(OfertaDTORegistro ofertadto)
        {
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
        [Route("Empresa/{id}")]
        public ActionResult<List<OfertaDTO>> GetofertasEmpresa([FromRoute] int id)
        {
            var lista = ofertaBL.obtenerOfertasempresa(id);
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
