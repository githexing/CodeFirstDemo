﻿using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Areas.Admin.Models.System
{    
    public class RoleAddViewModel
    {
        public List<Permissions> PermissionList { get; set; }
    }
    public class Permissions
    {
        public PermissionDTO Parent { get; set; }
        public PermissionDTO[] Child { get; set; }
    }
}