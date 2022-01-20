using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO.ProvinciasDTO;
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

    public class ProvinciasController : ControllerBase
    {
        private IProvinciasBL ProvinciasBL;
        public ProvinciasController(IProvinciasBL ProvinciasBL)
        {
            this.ProvinciasBL = ProvinciasBL;
        }

        [HttpGet]
        public ActionResult<List<ProvinciasDTO>> obtenertodoProvincias()
        {
            return Ok(ProvinciasBL.ObtenerTodoProvincia());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProvinciasDTO> obtenertodoProvincias(int id)
        {
            return Ok(ProvinciasBL.ObtenerProvincia(id));
        }
    }
}
