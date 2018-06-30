using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{    
    public class SecurityEntity:BaseEntity
    {
        public int SecurityID { get; set; }
        public string Question { get; set; }
        public long AddUserID { get; set; }
    }
}
