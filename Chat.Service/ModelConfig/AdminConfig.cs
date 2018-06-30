using Chat.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.ModelConfig
{
    class AdminConfig : EntityTypeConfiguration<AdminEntity>
    {
        /// <summary>
        /// ����Ա�û��������ݿ������
        /// </summary>
        public AdminConfig()
        {
            ToTable("tb_Admin");
            //��Զ��ϵ���ã����ûὨһ�Ź�ϵ�����Զ��ϵ
            HasMany(r => r.Roles).WithMany(u => u.AdminUsers).Map(m => m.ToTable("tb_AdminUserRole").MapLeftKey("AdminUserID").MapRightKey("RoleID"));
            //string �������ã������������ɵı��ֶ��Ǳ���ģ��ַ�������50
            Property(u => u.UserName).IsRequired().HasMaxLength(50);
            Property(u => u.TrueName).HasMaxLength(50);
            Property(u => u.Password).HasMaxLength(100).IsRequired().IsUnicode(false);
            Property(u => u.SecondPassword).HasMaxLength(100).IsRequired().IsUnicode(false);
            Property(u => u.ThirdPassword).HasMaxLength(100).IsRequired().IsUnicode(false);
            Property(u => u.FourPassword).HasMaxLength(100).IsUnicode(false);
        }
    }
}
