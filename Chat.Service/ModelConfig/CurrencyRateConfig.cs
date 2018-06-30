using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class CurrencyRateConfig : EntityTypeConfiguration<CurrencyRateEntity>
    {
        public CurrencyRateConfig()
        {
            ToTable("tb_CurrencyRate");

            Property(u => u.Name).HasMaxLength(50);
            Property(u => u.NameEn).HasMaxLength(50);
        }
    }
}