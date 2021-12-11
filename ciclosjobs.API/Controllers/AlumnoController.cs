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
        public ActionResult Register(AlumnoDTORegistro alumnoDTO)
        {
            if (alumnoBL.CrearAlumno(alumnoDTO))
                return Ok();
            else
                return Unauthorized();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<int> Login(AlumnoDTOLogin alumnoDTO)
        {
            int alumnoid;
            if ((alumnoid = alumnoBL.Login(alumnoDTO))!=-1)
                return Ok(alumnoid);
            else
                return Unauthorized();
        }

        [HttpDelete]
        public ActionResult EliminarAlumno(AlumnoDTOUpdate alumnoDTO)
        {
            
            if (alumnoBL.EliminarAlumno(alumnoDTO))
                return Ok();
            else
                return Unauthorized();
        }

        [HttpPut]
        public ActionResult<int> Actualizar(AlumnoDTOUpdate alumnoDTO)
        {
            int alumnoid;
            if ((alumnoid = alumnoBL.ActualizarAlumno(alumnoDTO)) != -1)
                return Ok(alumnoid);
            else
                return Unauthorized();
        }

        [HttpGet]
        public ActionResult<AlumnoDTO> get(int id)
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
            var alumno = alumnoBL.ObtenerTodosAlumnos();
            if (alumno != null)
                return Ok(alumno);
            else
                return Unauthorized();
        }


    }
}
