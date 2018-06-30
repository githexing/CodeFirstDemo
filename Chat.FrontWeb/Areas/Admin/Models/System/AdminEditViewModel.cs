﻿using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Areas.Admin.Models.System
{
    public class AdminEditViewModel
    {
        public AdminEditDTO Admin { get; set; }
        public RoleDTO[] Roles { get; set; }
        public List<long> RoleIds { get; set; }
    }
}