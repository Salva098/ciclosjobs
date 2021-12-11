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
    public class AlumnoController : ControllerBase
    {
        public IAlumnoBL alumnoBL { get; set; }
        public AlumnoController(IAlumnoBL alumnoBL)
        {
            this.alumnoBL = alumnoBL;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(AlumnoDTO alumnoDTO)
        {
            AlumnoDTO alumno;
            if ((alumno = alumnoBL.crearAlumno(alumnoDTO)) != null)
                return Ok();
            else
                return Unauthorized();
        }
        [HttpGet]
        [Route("getAlumno")]
        public ActionResult<AlumnoDTO>   get(int id)
        {
            AlumnoDTO alumno;
            if ((alumno = alumnoBL.ObtenerAlumno(id)) != null)
                return Ok(alumno);
            else
                return Unauthorized();
        }
        [HttpGet]
        [Route("getAllAlumno")]
        public ActionResult<AlumnoDTO> getall()
        {
            var alumno = alumnoBL.obtenerTodosAlumnos();
            if (alumno != null)
                return Ok(alumno);
            else
                return Unauthorized();
        }


    }
}
