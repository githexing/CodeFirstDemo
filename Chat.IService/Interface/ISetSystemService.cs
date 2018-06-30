using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface ISetSystemService : IServiceSupport
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="state"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        long AddSetSystem(int state, string remark);

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <param name="remark"></param>
        /// <returns>0:更新成功,1:更新失败,2:不存在</returns>
        int UpdateSystem(long id, int state, string remark);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        SetSystemDTO GetModelByID(long ID);

        SetSystemDTO GetFirstModelByID();
    }
}
