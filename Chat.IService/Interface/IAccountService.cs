using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chat.IService.Interface
{
    public interface IAccountService: IServiceSupport
    {
        // 获得总收入
        decimal GetIncomeTotal();
        /// 获得总支出
        decimal GetPayTotal();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="ToUserCode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        AccountPageResult GetPageList(long UserID, DateTime? start, DateTime? end, int pageIndex, int pageSize);
    }


    public class AccountPageResult
    {
        public AccountDTO[] AccountList { get; set; }
        public long TotalCount { get; set; }
    }
}
