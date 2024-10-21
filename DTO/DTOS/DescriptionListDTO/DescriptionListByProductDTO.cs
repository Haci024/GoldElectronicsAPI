using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.DescriptionListDTO
{
    public class DescriptionListByProductDTO
    {
        public Guid Id { get; set; }

        public Guid ProductId {  get; set; }

        public string Description { get; set; }

        public string SkillName { get; set; }

    }
}
