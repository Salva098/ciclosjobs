using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO.InscripcionesDTO;
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
    public class InscripcionesController : ControllerBase
    {
        public IInscripcioneBL InscripcioneBL { get; set; }
        public InscripcionesController(IInscripcioneBL InscripcioneBL)
        {
            this.InscripcioneBL = InscripcioneBL;
        }

        [HttpGet]
        public ActionResult<List<InscripcionesDTO>> GetallInscripciones()
        {
            var lista = InscripcioneBL.GetAllInscripciones();
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
        [Route("Alumno/{idAlumno}/{idOferta}")]
        public ActionResult<int> Checkinscripcion([FromRoute] int idAlumno, [FromRoute] int idOferta)
        {
            int id = InscripcioneBL.Checkinscripcion(idAlumno, idOferta);
            if (id!=-1)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(id);
            }
        }

            [HttpGet]
        [Route("{id}")]
        public ActionResult<InscripcionesDTO> GetInscripciones([FromRoute] int id)
        {
            var inscripciones = InscripcioneBL.GetInscripciones(id);
            if (inscripciones != null)
            {
                return Ok(inscripciones);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<int> CreateInscripciones(InscripcionesDTOCreate inscripcion)
        {
            var inscripciones = InscripcioneBL.CrearInscripcion(inscripcion);
            if (inscripciones!=-1)
            {
                return Ok(inscripciones);

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult DeleteInscripciones(int id) {

            var inscripcion = InscripcioneBL.DeleteInscripciones(id);
            if (inscripcion)
            {
                return Ok();

            }   
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateInscripciones(InscripcionesDTOUpdate inscripciones)
        {
            var inscripcion = InscripcioneBL.UpdateInscripciones(inscripciones);
            if (inscripcion)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Familia/{id}")]

        public ActionResult<List<InscripcionesDTO>> GetInscripcionesFamilia([FromRoute] int id)
        {
            var lista = InscripcioneBL.GetInscripcionesFamilia(id);
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
        [Route("Tipo/{id}")]
        public ActionResult<List<InscripcionesDTO>> GetInscripcionesTipo([FromRoute] int id)
        {
            var lista = InscripcioneBL.GetInscripcionesTipo(id);
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
        [Route("FamiliaTipo/{idfamilia}/{idtipo}")]
        public ActionResult<List<InscripcionesDTO>> GetInscripcionesfamiliaTipo([FromRoute] int idfamilia, [FromRoute] int idtipo)
        {
            var lista = InscripcioneBL.GetInscripcionesfamiliaTipo(idfamilia, idtipo);
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
        [Route("Ciclo/{id}")]
        public ActionResult<List<InscripcionesDTO>> GetInscripcionesCiclo([FromRoute] int id)
        {
            var lista = InscripcioneBL.GetInscripcionesCiclo(id);
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
        [Route("Alumno/{id}")]
        public ActionResult<List<InscripcionesDTO>> GetInscripcionesAlumno([FromRoute] int id)
        {
            var lista = InscripcioneBL.GetInscripcionesAlumno(id);
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
        public ActionResult<List<InscripcionesDTO>> GetInscripcionesEmpresa([FromRoute] int id)
        {
            var lista = InscripcioneBL.GetInscripcionesEmpresa(id);
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
