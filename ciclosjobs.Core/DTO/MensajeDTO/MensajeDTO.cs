using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO.MensajeDTO
{
    public class MensajeDTO
    {
        public int id { get; set; }
        public int alumnoid { get; set; }


        public AlumnoDTO Alumno { get; set; }

        public int empresaid { get; set; }

        public EmpresaDTO Empresa { get; set; }
        public string mensaje { get; set; }
        public bool leido { get; set; }
    }
}
