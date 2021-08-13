using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoComponente.Data.Entidades
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public char Sex { get; set; }
    }
}
