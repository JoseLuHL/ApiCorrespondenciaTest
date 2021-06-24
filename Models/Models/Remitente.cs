using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Remitente
    {
        public Remitente()
        {
            Correspondencia = new HashSet<Correspondencia>();
        }

        public int IdRemitente { get; set; }

        public virtual Persona IdRemitenteNavigation { get; set; }
        public virtual ICollection<Correspondencia> Correspondencia { get; set; }
    }
}
