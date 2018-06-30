using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DTO.DTO
{
    public class SetSystemDTO : BaseDTO
    {
        public int IsOpenWeb { get; set; }
        public string CloseWebRemark { get; set; }
    }

}
