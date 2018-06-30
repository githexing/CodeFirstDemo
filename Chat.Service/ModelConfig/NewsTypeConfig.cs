using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Chat.Service.ModelConfig
{
    class NewsTypeConfig : EntityTypeConfiguration<NewsTypeEntity>
    {
        public NewsTypeConfig()
        {
            ToTable("tb_NewsType");
            Property(u => u.NewTypeName).HasMaxLength(20);
         
        }
    }
}
