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
    public class SetSystemService : ISetSystemService
    {
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="state"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public long AddSetSystem(int state, string remark)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                SetSystemEntity entity = new SetSystemEntity();
                entity.IsOpenWeb = state;
                entity.CloseWebRemark = remark;
                dbcontext.SetSystem.Add(entity);
                dbcontext.SaveChanges();
                return entity.ID;
            }
        } 
        #endregion

        #region 更改前台开放设置
        /// <summary>
        /// 更改前台开放设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <param name="remark"></param>
        /// <returns>0:更新成功,1:更新失败,2:不存在</returns>
        public int UpdateSystem(long id, int state, string remark)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SetSystemEntity> cs = new CommonService<SetSystemEntity>(dbcontext);
                SetSystemEntity model = cs.GetById(id);
                if (model == null)
                {
                    return 2;//不存在
                }
                model.IsOpenWeb = state;
                model.CloseWebRemark = remark;
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
        #endregion

        #region 根据ID查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SetSystemDTO GetModelByID(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SetSystemEntity> cs = new CommonService<SetSystemEntity>(dbcontext);
                SetSystemEntity re = cs.GetById(ID);
                SetSystemDTO model = null;
                if (re != null)
                {
                    model = ToDTO(re);
                }
                return model;
            }
        }
        #endregion


        public SetSystemDTO GetFirstModelByID()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<SetSystemEntity> cs = new CommonService<SetSystemEntity>(dbcontext);
                SetSystemEntity re = cs.GetAll().FirstOrDefault();// cs.GetById(ID);
                SetSystemDTO model = null;
                if (re != null)
                {
                    model = ToDTO(re);
                }
                return model;
            }
        }

        public SetSystemDTO ToDTO(SetSystemEntity model)
        {
            SetSystemDTO dto = new SetSystemDTO();
            dto.ID = model.ID;
            dto.IsOpenWeb = model.IsOpenWeb;
            dto.CloseWebRemark = model.CloseWebRemark;
            dto.CreateTime = model.CreateTime;

            return dto;
        }

    }
}
