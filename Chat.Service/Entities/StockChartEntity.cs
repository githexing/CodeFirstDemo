using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{    
    public class StockChartEntity:BaseEntity
    {
        public DateTime? AddTime { get; set; }
        public decimal? StockPrice { get; set; }
    }
}
