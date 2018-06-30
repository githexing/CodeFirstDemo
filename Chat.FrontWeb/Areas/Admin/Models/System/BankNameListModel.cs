using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.DTO.DTO;

namespace Chat.FrontWeb.Areas.Admin.Models.System
{
    public class BankNameListModel
    {
        public List<BankNameDTO> bankList { get; set; }
    }
}