using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Empresa
    {
        [Key]
        public int id { get; set; }
        public string email{ get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }

        public int  idprovincias{ get; set; }

        [ForeignKey("idprovincias")]
        public Provincias provincias { get; set; }

        public string localidad { get; set; }
        public string direccion { get; set; }
    }
}
