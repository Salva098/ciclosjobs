using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Provincias
    {
        [Key]
        public int id { get; set; }
        public string provincias { set; get; }
    }
}
