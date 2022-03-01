using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class ContratoEstado
    {
        [Key]
        public int EstadoID { get; set; }
        public string NombreEstado { get; set; }
    }
}