using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.Service.Entities;
using Chat.WebCommon;
using System;
using System.Data.Entity;
using System.Linq;


namespace Chat.Service.Service
{
    public class AccountService: IAccountService
    {
        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<UserRecordEntity> cs = new CommonService<UserRecordEntity>(dbc);

                var money = cs.GetAll().Where(s => s.ReType == 2).Select(m => m.ReMoney).ToList().Sum();
                
                return money;
            }

        }
        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<BonusEntity> cs = new CommonService<BonusEntity>(dbc);

                var money = cs.GetAll().Select(m => m.Sf).ToList().Sum();

                return money;
            }
            
        }
        #region 分页查询
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
        public AccountPageResult GetPageList(long UserID, DateTime? start, DateTime? end, int pageIndex, int pageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<UserRecordEntity> record = new CommonService<UserRecordEntity>(dbcontext);
                CommonService<BonusEntity> bonus = new CommonService<BonusEntity>(dbcontext);
                AccountPageResult pageResult = new AccountPageResult();
                var recordQuery = record.GetAll();
                var bonusQuery = bonus.GetAll();
                var bonusGroup = bonusQuery.GroupBy(bg => bg.AddTime).Select(y => new { BDate = y.Key, zc = y.Sum(m => m.Amount) });
                var qeury = recordQuery.GroupBy(rg => DbFunctions.TruncateTime(rg.RecordTime)).Select(s => new { RDate = s.Key, sr = s.Sum(w => w.ReMoney) })
                    .Join(bonusGroup, r => r.RDate, b => DbFunctions.TruncateTime(b.BDate), (r, b) => new { r.RDate, r.sr, b.zc });

                pageResult.TotalCount = qeury.Count();
                pageResult.AccountList = qeury.OrderByDescending(p => p.RDate).Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList()
                    .Select(p => new AccountDTO { recordTime = (DateTime)p.RDate, zc = p.zc, sr = p.sr, yl = p.sr - p.zc })
                    .ToArray();
                return pageResult;
            }
        }
        #endregion

    }
}
