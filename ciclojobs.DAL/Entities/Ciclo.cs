using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace ciclojobs.DAL.Entities
{
    
    public class Ciclo
    {
        public Ciclo()
        {
            this.oferta = new HashSet<Ofertas>();
        }
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        
        public int idfamiliaprofe { get; set; }
        [ForeignKey("idfamiliaprofe")]
        public FamiliaProfe familia { get; set; }

        public int idtipo { get; set; }
        [ForeignKey("idtipo")]
        public TipoCiclo TipoCiclo { get; set; }
        public ICollection<Ofertas> oferta { get; set; }

    }
}
