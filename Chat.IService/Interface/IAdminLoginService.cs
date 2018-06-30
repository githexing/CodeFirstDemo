using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chat.IService.Interface
{
    public interface IAdminLoginService : IServiceSupport
    {
        int AdminLogin(string usercode, string password);
    }
}
