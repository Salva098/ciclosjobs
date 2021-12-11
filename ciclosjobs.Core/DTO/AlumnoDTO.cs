using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class AlumnoDTO
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string email { get; set; }


        public string apellidos { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int idprovincias { get; set; }
        public Provincias provincia { get; set; }
        public string localidad { get; set; }
        public int id_ciclo { get; set; }
        public Ciclo Ciclo { get; set; }
        public double calificacion_media { get; set; }
        public string foto { get; set; }
    }
}
