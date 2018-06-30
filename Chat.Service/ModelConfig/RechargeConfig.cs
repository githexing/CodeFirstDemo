using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class RechargeConfig : EntityTypeConfiguration<RechargeEntity>
    {
        public RechargeConfig()
        {
            ToTable("tb_Recharge");

            HasRequired(e => e.Users).WithMany().HasForeignKey(e => e.UserID).WillCascadeOnDelete(false);
            HasRequired(e => e.CurrencyNames).WithMany().HasForeignKey(e => e.RechargeType).WillCascadeOnDelete(false);
        }
    }
}