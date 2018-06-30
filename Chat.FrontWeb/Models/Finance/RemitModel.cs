using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.DTO.DTO;

namespace Chat.FrontWeb.Models.Finance
{
    public class RemitModel
    {
        public decimal emoney { get; set; }
        public List<BankNameDTO> bankoutList { get; set; }
        public string sysbankList { get; set; }
    }
}