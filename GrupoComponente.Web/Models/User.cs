using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoComponente.Web.Models
{
    public class User
    {
        public Int64 Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required]
        public DateTime BirthDay { get; set; }

        [DisplayName("Sexo")]
        [Required]
        public char Sex { get; set; }
    }
}