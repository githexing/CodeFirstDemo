using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Service.Entities;

namespace Chat.Service.ModelConfig
{
    public class ChangeTypeConfig : EntityTypeConfiguration<ChangeTypeEntity>
    {
        public ChangeTypeConfig()
        {
            ToTable("tb_ChangeType");

            Property(u => u.TypeName).HasMaxLength(50);
            Property(u => u.TypeNameEn).HasMaxLength(50);
        }
    }
}
