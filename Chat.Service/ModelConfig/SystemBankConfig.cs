using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class SystemBankConfig : EntityTypeConfiguration<SystemBankEntity>
    {
        public SystemBankConfig()
        {
            ToTable("tb_SystemBank");
        }
    }
}