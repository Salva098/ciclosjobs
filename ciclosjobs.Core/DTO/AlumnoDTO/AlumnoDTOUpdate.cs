using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class AlumnoDTOUpdate : LoginDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int idprovincias { get; set; }
        public string localidad { get; set; }
        public int id_ciclo { get; set; }
        public double calificacion_media { get; set; }
        public string foto { get; set; }
    }
}
