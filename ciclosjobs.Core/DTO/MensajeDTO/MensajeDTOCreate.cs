using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO.MensajeDTO
{
   public class MensajeDTOCreate
    {
        public int id { get; set; }
        public int alumnoid { get; set; }
        public int empresaid { get; set; }

        public string mensaje { get; set; }
    }
}
