using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class SMSConfig : EntityTypeConfiguration<SMSEntity>
    {
        public SMSConfig()
        {
            ToTable("tb_SMS");
        }
    }
}