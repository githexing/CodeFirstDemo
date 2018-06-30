using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace Chat.FrontWeb.Areas.Admin.Models.Finance
{
    public class AccountModel
    {
        public AccountDTO[] accountList { get; set; }
        public string Page { get; set; }
        public AccountDTO AccountTotol { get; set; }
    }
}   