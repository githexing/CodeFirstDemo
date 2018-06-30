using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Areas.Admin.Models.System
{
    public class AdminListViewModel
    {
        public AdminListDTO[] AdminList { get; set; }
        public string Page { get; set; }
    }
}