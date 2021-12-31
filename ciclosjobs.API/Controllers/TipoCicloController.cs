using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO.FamiliaProfeDTO;
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
    public class TipoCicloController : ControllerBase
    {
        public ITipoCicloBL tipocicloBL { get; set; }
        public TipoCicloController(ITipoCicloBL tipocicloBL)
        {
            this.tipocicloBL = tipocicloBL;
        }

        [HttpGet]
        public ActionResult<List<TipoCicloDTO>> getAllTipoCiclo()
        {
            return Ok(this.tipocicloBL.getAllTiposCiclos());
        }

    }
}
