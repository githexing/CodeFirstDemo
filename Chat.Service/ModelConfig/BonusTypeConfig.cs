using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class BonusTypeConfig : EntityTypeConfiguration<BonusTypeEntity>
    {
        public BonusTypeConfig()
        {
            ToTable("tb_BonusType");
            Property(u => u.TypeName).HasMaxLength(50);
            Property(u => u.TypeNameEn).HasMaxLength(50);
        }
    }
}