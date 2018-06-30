﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.DTO.DTO;

namespace Chat.FrontWeb.Areas.Admin.Models.Agent
{
    public class AgentListViewModel
    {
        public AgentListDTO[] AgentListDTO { get;set;}
        public string Page { get; set; }
        /// <summary>
        /// 0为未激活报单中心，1为激活报单中心
        /// </summary>
        public int Flag { get; set; }
    }
}