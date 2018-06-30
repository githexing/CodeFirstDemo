﻿using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.WebCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.FrontWeb.Areas.Admin.Controllers.Base
{
    /// <summary>
    /// 后台公共基类，验证是否登录
    /// </summary>
    public class AdminBaseController : Controller
    {
        public IAdminService adminService { get; set; }
        public int pageIndex = 1;
        public int pageSize = 5;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["A128076_admin"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                {
                    filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0",Msg= "登录信息已经过期，请刷新重新登录！", Data = "/admin/user/login" } };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/admin/user/login");
                }
            }
            if (Request.Params["pageIndex"] != null)
            {
                pageIndex = Convert.ToInt32(Request.Params["pageIndex"]);
            }
            if (Request.Params["pageSize"] != null)
            {
                pageSize = Convert.ToInt32(Request.Params["pageSize"]);
            }
            base.OnActionExecuting(filterContext);
        }

        public long GetLoginID()
        {
            if (HttpContext.Request.Cookies["A128076_admin"] != null)
            {
                return Convert.ToInt32(HttpContext.Request.Cookies["A128076_admin"]["ID"]);
            }
            else
            {
                return 0;
            }
        }

        public AdminDTO GetUserInfo()
        {
            if (GetLoginID() == 0)
            {
                return null;
            }
            return adminService.GetByAdminId(GetLoginID());
        }
    }
}