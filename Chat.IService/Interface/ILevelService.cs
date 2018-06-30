using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface ILevelService : IServiceSupport
    {
        LevelDTO[] GetAll();
        LevelDTO GetLevelName(int LevelID);
    }
}
