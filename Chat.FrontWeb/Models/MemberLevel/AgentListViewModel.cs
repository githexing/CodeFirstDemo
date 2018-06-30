using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.DTO.DTO;

namespace Chat.FrontWeb.Models.MemberLevel
{
    public class AgentListViewModel
    {
        public AgentListDTO AgentList { get; set; }
        public MemberListDTO Member { get; set; }
        public AgentListDTO[] Agent { get; set; }
    }
}