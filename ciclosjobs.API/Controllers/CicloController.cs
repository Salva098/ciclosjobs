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
    [AllowAnonymous]

    public class CicloController : ControllerBase
    {

        public ICicloBL cicloBL { get; set; }
        public CicloController(ICicloBL cicloBL)
        {
            this.cicloBL = cicloBL;
        }

        [HttpGet]
        public ActionResult<List<CicloDTO>> GetTodoCiclos()
        {
            var lista = cicloBL.ObtenerTodoCiclo();
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
        public ActionResult<OfertaDTO> GetCicloid([FromRoute] int id)
        {
            var ciclo = cicloBL.ObtenerCiclo(id);
            if (ciclo!= null)
            {
                return Ok(ciclo);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{idtipo}/{idfamilia}")]
        public ActionResult<OfertaDTO> GetCicloTipoFamilia([FromRoute] int idtipo, [FromRoute] int idfamilia)
        {
            var lista = cicloBL.GetCicloTipoFamilia(idtipo,idfamilia);
            if (lista.Count >= 1)
            {
                return Ok(lista);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
