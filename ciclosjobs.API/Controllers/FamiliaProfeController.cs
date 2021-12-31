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
    public class FamiliaProfeController : ControllerBase
    {
        public IFamiliaProfeBL FamiliaProfeBL { get; set; }

        public FamiliaProfeController(IFamiliaProfeBL FamiliaProfeBL)
        {
            this.FamiliaProfeBL = FamiliaProfeBL;
        }



        [HttpGet]
        public ActionResult<List<FamiliaProfeDTO>> getAllFamiliaProfe()
        {
            return Ok(this.FamiliaProfeBL.getAllFamiliaProfe());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<FamiliaProfeDTO>> getFamiliaProfe([FromRoute] int id)
        {
            return Ok(this.FamiliaProfeBL.getFamiliaProfe(id));
        }
    }
}
