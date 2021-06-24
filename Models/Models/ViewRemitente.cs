using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class ViewRemitente
    {
        public int IdPersona { get; set; }
        public int? Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Telefono { get; set; }
        public string Crreo { get; set; }
        public string Direccion { get; set; }
        public int? IdTipoIdentificacion { get; set; }
    }
}
