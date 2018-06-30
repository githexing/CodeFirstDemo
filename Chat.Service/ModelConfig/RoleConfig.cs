﻿using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class RoleConfig : EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfig()
        {
            ToTable("tb_Role");
            HasMany(r => r.Permissions).WithMany(p => p.Roles).Map(m => m.ToTable("tb_RolePermission").MapLeftKey("RoleID").MapRightKey("PermissionID"));
            Property(r => r.Name).HasMaxLength(50).IsRequired();
            Property(r => r.Description).HasMaxLength(1024).IsRequired();
        }
    }
}
