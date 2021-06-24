using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Models.Models
{
    public partial class Correspondencia
    {
        public string IdCorrespondencia { get; set; }
        [JsonIgnore]

        public int IdTipoCorrespondencia { get; set; }
        public string DireccionRemitente { get; set; }
        public string Observacion { get; set; }
        public string Telefono1Remitente { get; set; }
        public string Telefono2Remitente { get; set; }
        public string Telefono1Destinatario { get; set; }
        public string Telefono2Destinatario { get; set; }
        public string ArchivoAdjunto { get; set; }
        public DateTime? Fecha { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int IdRemitente { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int IdDestinatario { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int IdEstado { get; set; }
        public virtual Destinatario ObjIdDestinatario { get; set; }
        public virtual Lookup ObjIdEstado { get; set; }
        public virtual Remitente ObjIdRemitente { get; set; }
        public virtual Lookup ObjIdTipoCorrespondencia { get; set; }
    }
}
