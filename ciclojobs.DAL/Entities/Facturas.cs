using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Facturas
    {
        [Key]
        public int id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaFin { get; set; }

        public int EmpresaID { get; set; }

        [ForeignKey("EmpresaID")]
        public Empresa Empresa { get; set; }
        public string StripePriceID { get; set; }
        public int ContratoID { get; set; }

        [ForeignKey("ContratoID")]
        public Contrato Contrato { get; set; }
    }
}
