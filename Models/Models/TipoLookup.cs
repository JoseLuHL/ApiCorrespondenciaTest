using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TipoLookup
    {
        public TipoLookup()
        {
            Lookups = new HashSet<Lookup>();
        }

        public int IdTipoLookup { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Lookup> Lookups { get; set; }
    }
}
