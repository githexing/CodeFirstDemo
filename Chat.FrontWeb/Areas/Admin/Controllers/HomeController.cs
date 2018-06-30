using Chat.DTO.DTO;
using Chat.FrontWeb.App_Start;
using Chat.FrontWeb.Areas.Admin.Controllers.Base;
using Chat.FrontWeb.Areas.Admin.Models;
using Chat.FrontWeb.Areas.Admin.Models.User;
using Chat.IService.Interface;
using Chat.Service.Service;
using Chat.WebCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Chat.FrontWeb.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IUserService userService { get; set; }
        //adminService已经在AdminBaseController中定义
        public IPowerService powerService { get; set; }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            
            List<ParentModel> MenuList = new List<ParentModel>();
            foreach (var parent in powerService.GetByParentID(0))
            {
                ParentModel parentList = new ParentModel();
                parentList.Parent = parent;
                if(powerService.GetByTypeId((int)parent.TypeID)==null)
                {
                    continue;
                }
                parentList.Child = powerService.GetByTypeId((int)parent.TypeID);
                MenuList.Add(parentList);
            }
            model.MenuList = MenuList;
            model.ID = GetLoginID();
            return View(model);
        }

        public ActionResult ExportExcel()
        {
            AdminSearchResult result= adminService.GetPageList(1, 10);            
            return File(ExcelHelper.ExportExcel<AdminListDTO>(result.AdminList, "管理员"), "application/vnd.ms-excel", "测试.xls");
        }

        public ActionResult ZhuYe()
        {
            return View();
        }

        public ActionResult MemberLine()
        {
            return View();
        }

        public ActionResult GetMemberCountList()
        {
            List<UserAllCountModel> ulist = userService.GetMemberNumGroupbyTime();

            return Json(new AjaxResult { Status = "1", Data = ulist });
        }

    }
}