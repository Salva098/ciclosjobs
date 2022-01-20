using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.Security;
using Microsoft.AspNetCore.Authorization;
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
    public class AlumnoController : ControllerBase
    {
        public IAlumnoBL alumnoBL { get; set; }
        public IJwtBearer JwtBearer { get; set; }
        public AlumnoController(IAlumnoBL alumnoBL, IJwtBearer JwtBearer)
        {
            this.alumnoBL = alumnoBL;
            this.JwtBearer = JwtBearer;
        }



        [HttpPost]
        [AllowAnonymous]

        public ActionResult Register(AlumnoDTORegistro alumnoDTO)
        {
            if (alumnoBL.CrearAlumno(alumnoDTO))
                return Ok();
            else
                return BadRequest();
        }



        [HttpPost]
        [AllowAnonymous]

        [Route("Login")]
        public ActionResult Login(LoginDTO alumnoDTO)
        {
            AlumnoDTO alumno;
            if ((alumno = alumnoBL.Login(alumnoDTO)) != null)
            {

            Response.Headers.Add("token", JwtBearer.GenerateJWTTokenAlumno(alumno));
            return Ok();
            }
            else
                return BadRequest();
        }



        [HttpDelete]
        public ActionResult EliminarAlumno(AlumnoDTOUpdate alumnoDTO)
        {

            if (alumnoBL.EliminarAlumno(alumnoDTO))
                return Ok();
            else
                return BadRequest();
        }



        [HttpPut]
        public ActionResult<int> Actualizar(AlumnoDTOUpdate alumnoDTO)
        {
            int alumnoid;
            if ((alumnoid = alumnoBL.ActualizarAlumno(alumnoDTO)) != -1)
                return Ok(alumnoid);
            else
                return BadRequest();
        }



        [HttpGet]
        [Route("{id}")]
        public ActionResult<AlumnoDTO> get([FromRoute] int id)
        {
            AlumnoDTO alumno;
            if ((alumno = alumnoBL.ObtenerAlumno(id)) != null)
                return Ok(alumno);
            else
                return BadRequest();
        }



        [HttpGet]
        public ActionResult<AlumnoDTO> getall()
        {
            var alumno = alumnoBL.ObtenerTodosAlumnos();
            if (alumno != null)
                return Ok(alumno);
            else
                return BadRequest();
        }


    }
}
