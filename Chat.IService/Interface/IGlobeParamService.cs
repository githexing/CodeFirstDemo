using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface IGlobeParamService:IServiceSupport
    {
        GlobeParamDTO[] GetAll();
        bool Update(long? id, string paramVarchar);
        GlobeParamDTO GetById(long? id);
        GlobeParamDTO GetByName(string name);
    }
}
