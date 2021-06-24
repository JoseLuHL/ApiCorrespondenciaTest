using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class FMenuHijoVo
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string ruta { get; set; }
        public int orden { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual int FMenuPadreVoid { get; set; }

    }
}
