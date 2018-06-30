using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.DTO.DTO;

namespace Chat.FrontWeb.Models.Finance
{
    public class RemitListModel
    {
        public RemitDTO[] remitList { get; set; }
        public string Page { get; set; }
    }
}