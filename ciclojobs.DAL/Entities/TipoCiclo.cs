using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{

    public class TipoCiclo
    {
        [Key]
        public int idtipo { get; set; }
        public string nombre { get; set; }
    }
}
