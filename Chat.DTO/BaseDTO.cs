using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DTO
{
    [Serializable]
    public abstract class BaseDTO
    {
        public long ID { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
