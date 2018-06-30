using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{    
    public class BankNameEntity : BaseEntity
    {
        public string BankName { get; set; }
        public string BankNameEn { get; set; }
    }
}
