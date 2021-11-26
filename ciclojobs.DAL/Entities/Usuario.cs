using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ciclojobs.DAL.Entities
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }

    }
}
