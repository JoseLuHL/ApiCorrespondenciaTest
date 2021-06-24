using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class FMenuPadreVo
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public int orden { get; set; }

        public List<FMenuHijoVo> submenu { get; set; }
    }
}
