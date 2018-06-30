using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{    
    public class UserRecordEntity:BaseEntity
    {
        public string RecordName { get; set; }
        public DateTime RecordTime { get; set; }
        public decimal ReMoney { get; set; }
        public int ReType { get; set; }
    }
}
