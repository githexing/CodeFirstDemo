﻿using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Areas.Admin.Models.Message
{
    public class LeaveWordsDetailModel
    {
          public LeaveMsgDTO data { get; set; }
         
          public LeaveReMsgDTO[] leaveReMsgList { get; set; }
          public string Page { get; set; }
    }
}