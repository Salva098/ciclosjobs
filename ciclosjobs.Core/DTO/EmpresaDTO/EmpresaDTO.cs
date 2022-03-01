using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class EmpresaDTO
    {
        public int id { get; set; }

        public string email { get; set; }
        public string nombre { get; set; }
        public int idprovincias { get; set; }
        public Provincias provincias { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
        public string StripeID { get; set; }
    }
}
