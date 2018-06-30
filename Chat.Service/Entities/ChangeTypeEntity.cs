using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Entities
{
    public class ChangeTypeEntity : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeNameEn { get; set; }
    }
}
