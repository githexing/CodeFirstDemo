using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class GlobeParamConfig : EntityTypeConfiguration<GlobeParamEntity>
    {
        public GlobeParamConfig()
        {
            ToTable("tb_GlobeParam");

            Property(u => u.ParamName).HasMaxLength(50);
            Property(u => u.ParamVarchar).HasMaxLength(150);
            Property(u => u.Remark).HasMaxLength(50);
            Property(u => u.EndRemark).HasMaxLength(50);
        }
    }
}