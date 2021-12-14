using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Ofertas
    {
        public Ofertas()
        {
            this.ciclo = new HashSet<Ciclo>();
        }
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double remuneracion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public String Horario { get; set; }
        public int idempresas { get; set; }
        [ForeignKey("idempresas")]
        public Empresa empresas { get; set; }

        public ICollection<Ciclo> ciclo { get; set; }
    }
}
