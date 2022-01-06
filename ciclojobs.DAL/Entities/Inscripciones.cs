 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Inscripciones
    {
        [Key]
        public int Id { get; set; }

        public int idAlumno { get; set; }
        [ForeignKey("idAlumno")]
        public Alumno Alumno { get; set; }

        public int OfertaId { get; set; }
        [ForeignKey("OfertaId")]
        public Ofertas Oferta { get; set; }

        public DateTime FechaInscripcion { get; set; }
        public String EstadoInscripción { get; set; }
    }
}
