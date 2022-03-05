using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Contrato
    {
        [Key]
        public int id { set; get; }
        public int EmpresaID { set; get; }
        [ForeignKey("EmpresaID")]
        public Empresa Empresa { get; set; }
        public DateTime FehchaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public ContratoEstado EstadoContrato { get; set; }
        public string StripeId { get; set; }
    }
}
