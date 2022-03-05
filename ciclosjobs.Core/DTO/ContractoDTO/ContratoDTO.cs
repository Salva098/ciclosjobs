using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO.ContractoDTO
{
    public class ContratoDTO
    {
        public int id { set; get; }
        public int EmpresaID { set; get; }
        public Empresa Empresa { get; set; }
        public DateTime FehchaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public ContratoEstado EstadoContrato { get; set; }
        public string StripeId { get; set; }
    }
}
