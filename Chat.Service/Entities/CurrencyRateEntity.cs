using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{    
    public class CurrencyRateEntity:BaseEntity
    {
        public string Name { get; set; }
        public decimal? Rate { get; set; }
        public string NameEn { get; set; }
    }
}
