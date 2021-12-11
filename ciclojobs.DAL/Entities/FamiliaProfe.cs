using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class FamiliaProfe
    {
        [Key]
        public int idprofe { get; set; }
        public string  nombre { get; set; }

    }
}
