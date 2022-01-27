using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ciclojobs.DAL.Entities
{

    public class Alumno
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechanacimiento { get; set; }

        public int idprovincias { get; set; }
        [ForeignKey("idprovincias")]
        public Provincias provincia { get; set; }
        public string localidad { get; set; }
        public int id_ciclo { get; set; }
        [ForeignKey("id_ciclo")]
        public Ciclo ciclo { get; set; }
        public double calificacion_media { get; set; }
        public string foto { get; set; }
        public string codeverify { get; set; }

        [DefaultValue(false)]
        public bool verificado { get; set; }

        public List<Inscripciones> inscripciones { get; set; }
    }
}
