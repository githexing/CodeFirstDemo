using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class AreaConfig : EntityTypeConfiguration<AreaEntity>
    {
        public AreaConfig()
        {
            ToTable("tb_Area");

            Property(u => u.AreaID).HasMaxLength(50);
            Property(u => u.Area).HasMaxLength(50);
            Property(u => u.Father).HasMaxLength(50);
        }
    }
}