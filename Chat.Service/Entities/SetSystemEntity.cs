using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{
    public class SetSystemEntity:BaseEntity
    {
        public int IsOpenWeb { get; set; }
        public string CloseWebRemark { get; set; }
    }
}
