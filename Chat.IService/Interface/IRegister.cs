using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.DTO.DTO;

namespace Chat.IService.Interface
{
    public interface IRegister: IServiceSupport
    {
        /// <summary>
        /// 执行sql 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet DS(string sql);
        /// <summary>
        /// 查询ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        UserResult UserDTO(int ID);
    }
    public class UserResult
    {
        public IEnumerable<UserDTO> UserListDTO { get; set; }
        public UserDTO UserDTO { get; set; }
        public long TotalCount { get; set; }
    }
}
