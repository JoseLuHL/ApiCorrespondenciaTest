using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class OpcionModulo
    {
        public OpcionModulo()
        {
            Menus = new HashSet<Menu>();
        }

        public int IdOpcion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public int Orden { get; set; }
        public string Imagen { get; set; }
        public int IdModulo { get; set; }
        public bool Estado { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
