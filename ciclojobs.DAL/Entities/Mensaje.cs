using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Mensaje
    {
        [Key]
        public int id { get; set; }
        public int alumnoid { get; set; }

        [ForeignKey("alumnoid")]
        public Alumno Alumno { get; set; }

        public int empresaid { get; set; }
        [ForeignKey("empresaid")]
        public Empresa Empresa { get; set; }
        public string mensaje { get; set; }
        [DefaultValue(false)]
        public bool leido { get; set; }

    }
}
