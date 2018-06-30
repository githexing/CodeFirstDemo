using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.IService.Interface
{
    public interface IStockService: IServiceSupport
    {
        List<StockDTO> GetStockList(int pageIndex, int pageSize);
        List<StockDTO> GetStockCount();
        long Add(StockDTO model);
    }
}
