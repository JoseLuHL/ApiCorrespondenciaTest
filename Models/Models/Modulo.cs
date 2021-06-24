using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            OpcionModulos = new HashSet<OpcionModulo>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Ordern { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<OpcionModulo> OpcionModulos { get; set; }
    }
}
