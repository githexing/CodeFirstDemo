﻿using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class PermissionConfig:EntityTypeConfiguration<PermissionEntity>
    {
        public PermissionConfig()
        {
            ToTable("tb_Permission");
            Property(p => p.Description).HasMaxLength(1024).IsRequired();
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.URL).HasMaxLength(100).IsRequired();
            Property(p => p.MenuName).HasMaxLength(50).IsRequired();
        }
    }
}
