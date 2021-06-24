using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Models.Models
{
    public partial class Lookup
    {
        public Lookup()
        {
            CorrespondenciumIdEstadoNavigations = new HashSet<Correspondencia>();
            Menus = new HashSet<Menu>();
            Personas = new HashSet<Persona>();
        }

        public int IdLookup { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int IdTipoLookup { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Decripcion { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Codigo { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual TipoLookup IdTipoLookupNavigation { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Correspondencia CorrespondenciumIdTipoCorrespondenciaNavigation { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Correspondencia> CorrespondenciumIdEstadoNavigations { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Menu> Menus { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
