using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Destinatario
    {
        public Destinatario()
        {
            Correspondencia = new HashSet<Correspondencia>();
        }

        public int IdDestinatario { get; set; }

        public virtual Persona ObjIdDestinatario { get; set; }
        public virtual ICollection<Correspondencia> Correspondencia { get; set; }
    }
}
