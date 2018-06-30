using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface IPermissionService:IServiceSupport
    {
        PermissionDTO[] GetByParentId(long id);
        List<long> GetByRoleId(long id);
        List<long> GetByAdminId(long id);
        string GetByName(string name);
    }
}
