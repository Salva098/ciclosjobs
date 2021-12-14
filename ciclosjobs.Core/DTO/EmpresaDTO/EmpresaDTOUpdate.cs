using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class EmpresaDTOUpdate: LoginDTO
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public int idprovincias { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
    }
}
