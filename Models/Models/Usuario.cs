using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdPerfil { get; set; }
        public string Login { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? IdEstado { get; set; }
        public string Password { get; set; }
    }
}
