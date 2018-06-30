using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Service.Entities;

namespace Chat.Service.ModelConfig
{
    public class CurrencyNameConfig : EntityTypeConfiguration<CurrencyNameEntity>
    {
        public CurrencyNameConfig()
        {
            ToTable("tb_CurrencyName");

            Property(u => u.CurrencyName).HasMaxLength(50);
            Property(u => u.CurrencyNameEn).HasMaxLength(50);
        }
    }
}
