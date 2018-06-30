using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface ISecurityService : IServiceSupport
    {
        long AddSecurity(string question, long adduserid);
        int UpdateSecurity(long id, string question);
        int Delete(long id);
        List<SecurityDTO> GetList();
    }
}
