using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Models.Models
{
    public partial class Persona
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

        public virtual Lookup ObjIdTipoIdentificacion { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Destinatario Destinatario { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Remitente Remitente { get; set; }
    }
}
