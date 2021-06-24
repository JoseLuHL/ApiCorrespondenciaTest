using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public int IdOpcion { get; set; }
        public int IdPerfil { get; set; }
        public bool Estado { get; set; }

        public virtual OpcionModulo IdOpcionNavigation { get; set; }
        public virtual Lookup IdPerfilNavigation { get; set; }
    }
}
