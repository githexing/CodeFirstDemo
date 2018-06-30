using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface IGoodsService:IServiceSupport
    {
        long Add(GoodsDTO dto);
        bool Update(GoodsDTO dto);
        bool Delete(long ID);
        GoodsDTO GetModel(long ID);
        SearchResult GetModelList(string goodsName,string goodsCode,DateTime? startTime,DateTime endTime,int pageIndex,int pageSize);
    }
    public class SearchResult
    {
        public GoodsDTO[] Goods { get; set; }
        public long TotalCount { get; set; }
    }
}
