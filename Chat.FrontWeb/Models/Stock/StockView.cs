using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Models.Stock
{
    public class StockView
    {
        public List<StockDTO> StockViewList { set; get; }
        public int totalPage { set; get; }
        public int showPageNum { set; get; }
    }
}