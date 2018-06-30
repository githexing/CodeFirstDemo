using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Chat.FrontWeb.Models.Member
{
    public class LeaveMsgListModel
    {
        public LeaveMsgDTO[] leaveMsgList { get; set; }
        public string Page { get; set; }
    }
}