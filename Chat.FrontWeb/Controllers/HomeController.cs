using Chat.FrontWeb.Controllers.Base;
using Chat.IService.Interface;
using Chat.WebCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.FrontWeb.Controllers
{
    public class HomeController : FrontBaseController
    {
        public ICityService cityService { get; set; }
        public ILoginService loginService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
    }
}