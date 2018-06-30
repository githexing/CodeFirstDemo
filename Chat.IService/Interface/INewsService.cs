using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface INewsService : IServiceSupport
    {
        //增加公告
        long Add(string Title, int dropNewType, string Context, DateTime Time);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        NewsPageResult GetPageList(int PageIndex, int PageSize);
        ///获取id
        NewsDTO GetModel(long Id);
        //更新
        bool Update(NewsDTO hh);
        //前台列表
        NewsPageResult GetNewsList(int NewType,string Title, DateTime? Strat, DateTime? End, int PageIndex, int PageSize);
        //添加新闻类别名称
        int AddTypeName(NewsTypeDTO hh);
        //查询新闻Type
        NewsPageResult getdata();
        /// <summary>
        /// 删除修改类别名称
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int Del(long ID, int type, string name);
    }
    public class NewsPageResult
    {
        public long TotalCount { get; set; }
        public NewsDTO[] News { get; set; }
        public NewsTypeDTO NewsType { get; set; }
        public NewsTypeDTO[] NewsTypeList { get; set; }
    }
}
