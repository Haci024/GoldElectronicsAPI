using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.UsersDTO.RegisterDTO
{
    public class ConfirmMailDTO
    {

        public string Email { get; set; }

        public int ConfirmCode  { get; set; }
    }
}
