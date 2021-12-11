using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Ciclo_Oferta
    {
        public int Id { get; set; }

        public int idCiclo { get; set; }
        [ForeignKey("idCiclo")]

        public Ciclo ciclo { get; set; }

        public int OfertaId { get; set; }
        [ForeignKey("OfertaId")]

        public Ofertas Oferta { get; set; }
    }
}
