using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Service
{
    public class SecurityService : ISecurityService
    {
        public long AddSecurity(string question, long adduserid)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                SecurityEntity model = new SecurityEntity();
                model.SecurityID = 0;
                model.Question = question;
                model.AddUserID = adduserid;
                dbcontext.Security.Add(model);
                dbcontext.SaveChanges();
                return model.ID;
            }
        }
        
        public int UpdateSecurity(long id,string question)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SecurityEntity> cs = new CommonService<SecurityEntity>(dbcontext);
                SecurityEntity model = cs.GetById(id);
                if (model == null)
                {
                    return 2;//不存在
                }
                model.Question = question;
                int num = dbcontext.SaveChanges();
                if (num > 0)
                {
                    return 0;//更新成功
                }
                else
                {
                    return 1;//更新失败
                }
            }
        }

        public int Delete(long id)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SecurityEntity> cs = new CommonService<SecurityEntity>(dbcontext);
                SecurityEntity re = cs.GetById(id);
                if (re != null)
                {
                    re.IsDeleted = true;
                    int num = dbcontext.SaveChanges();
                    if (num > 0)
                    {
                        return 0;//删除成功
                    }
                    else
                    {
                        return 1;//删除失败
                    }
                }
                else
                {
                    return 2;//已删除
                }
            }
        }

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<SecurityDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SecurityEntity> csr = new CommonService<SecurityEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        public SecurityDTO ToDTO(SecurityEntity model)
        {
            SecurityDTO dto = new SecurityDTO();
            dto.ID = model.ID;
            dto.Question = model.Question;
            dto.CreateTime = model.CreateTime;
            return dto;
        }

    }
}
