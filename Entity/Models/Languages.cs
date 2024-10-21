using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Languages
    {
        [Key]
        public long Id { get; set; }
        public string Culture { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }


    }
}
