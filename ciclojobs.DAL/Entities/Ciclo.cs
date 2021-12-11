using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace ciclojobs.DAL.Entities
{
    
    public class Ciclo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        
        public int idfamiliaprofe { get; set; }
        [ForeignKey("idfamiliaprofe")]
        public FamiliaProfe familia { get; set; }

        public int idtipo { get; set; }
        [ForeignKey("idtipo")]
        public TipoCiclo TipoCiclo { get; set; }
        public List<Ciclo_Oferta> ciclo_oferta { get; set; }

    }
}
