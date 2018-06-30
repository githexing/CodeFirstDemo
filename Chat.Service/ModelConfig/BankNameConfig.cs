using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class BankNameConfig : EntityTypeConfiguration<BankNameEntity>
    {
        public BankNameConfig()
        {
            ToTable("tb_BankName");

            Property(u => u.BankName).HasMaxLength(50);
            Property(u => u.BankNameEn).HasMaxLength(50);
        }
    }
}