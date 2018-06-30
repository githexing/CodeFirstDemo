using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DTO.DTO
{
    public class SecurityDTO : BaseDTO
    {
        public string Question { get; set; }
        public long AddUserID { get; set; }
    }
}
