using Chat.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.FrontWeb.Areas.Admin.Models
{
    public class ParentModel
    {
        public PowerDTO Parent { get; set; }
        public PowerDTO[] Child { get; set; }
    }

    public class IndexViewModel
    {
        public List<ParentModel> MenuList { get; set; }
        public long ID { get; set; }
    }
}