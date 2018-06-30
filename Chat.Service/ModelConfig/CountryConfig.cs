using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class CountryConfig : EntityTypeConfiguration<CountryEntity>
    {
        public CountryConfig()
        {
            ToTable("tb_Country");

            Property(u => u.CountryID).HasMaxLength(50);
            Property(u => u.CountryName).HasMaxLength(50);
            Property(u => u.CountryName_en).HasMaxLength(50);
            Property(u => u.Code).HasMaxLength(50);
        }
    }
}