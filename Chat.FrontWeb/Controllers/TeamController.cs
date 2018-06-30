﻿using Chat.DTO.DTO;
using Chat.FrontWeb.Common;
using Chat.FrontWeb.Controllers.Base;
using Chat.IService.Interface;
using Chat.WebCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Chat.FrontWeb.Controllers
{
    public class TeamController : FrontBaseController
    {
        public IUserService UserServer { set; get; }
        public ILevelService lvelname { get; set; }
        public IBankNameService brank { set; get; }
        // GET: Team
        public ActionResult MemberTree()
        {
            return View(GetUserInfo().ID);
        }
        public string Tree(long Id,string code,int znode)
        {
            UserView uv = new UserView();
            //long Id = Convert.ToInt32(Request.Params["Id"]);
            //string code = Request.Params["code"];
            //int znode = Convert.ToInt32(Request.Params["znode"]);
            UserDTO model = UserServer.GetModelCode(code);
            if (model != null)
            {
                if (Id == 0)
                {
                    Id = model.ID;
                }

            }
            return uv.AddTable(Id, znode);
        }
        #region 注册
        public ActionResult Register()
        {
            ViewBag.LeveModelList = lvelname.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterModel(UserDTO model)
        {
            string msg = "";
            Validate(model);
            if (ModelState.IsValid)
            {
                UserDTO userParanmodel = UserServer.GetModelCode(model.ParentCode);//查询父级信息
                UserDTO userRecommendnmodel = UserServer.GetModelCode(model.RecommendCode);//查询推荐人信息
                if (userParanmodel != null && userRecommendnmodel != null)
                {
                    model.ParentID = int.Parse(userParanmodel.ID.ToString());
                    model.Layer = userParanmodel.Layer + 1;
                    model.AgentsID = 0;
                    model.Emoney = 0;
                    model.BonusAccount = 0;
                    model.AllBonusAccount = 0;
                    model.StockAccount = 0;
                    model.StockMoney = 0;
                    model.User003 = 0;
                    model.ShopAccount = 0;
                    model.LeftScore = 0;
                    model.LeftNewScore = 0;
                    model.LeftBalance = 0;
                    model.CenterScore = 0;
                    model.CenterNewScore = 0;
                    model.CenterBalance = 0;
                    model.RightScore = 0;
                    model.RightNewScore = 0;
                    model.RightBalance = 0;
                    model.IsOpend = 0;
                    model.IsLock = 0;
                    model.IsAgent = 0;
                    model.BillCount = 0;
                    model.RecommendGenera = userRecommendnmodel.RecommendGenera + 1;
                    model.RecommendID = int.Parse(userRecommendnmodel.ID.ToString());
                    model.RegMoney = 0;
                    model.RegTime = DateTime.Now;
                    model.CreateTime = DateTime.Now;
                    model.Password = CommonHelper.GetMD5(model.Password);
                    long Id = UserServer.Add(model);
                    if (Id > 0)
                    {
                        model.ID = Id;
                        model.UserPath = userParanmodel.UserPath + "-" + Id;
                        model.RecommendPath = userRecommendnmodel.RecommendPath + "-" + Id;
                        UserServer.UpdatePath(model);
                        msg = "注册成功";
                    }
                    else
                    {
                        msg = "注册失败";
                    }
                }
                else
                {
                    msg = "推荐人不存在或安置会员不存在";
                }
            }
            else
            {
                string error = string.Empty;
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state.Errors.Any())
                    {
                        error = state.Errors.First().ErrorMessage;
                        break;
                    }
                }
                msg = error;
            }

            return Content("<script>alert('" + msg + "');window.location='/Team/Register';</script>");
        }
        private void Validate(UserDTO model)
        {
            if (string.IsNullOrEmpty(model.UserCode))
            {
                ModelState.AddModelError("UserCode", "用户编号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "密码不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.LevelID.ToString()))
            {
                ModelState.AddModelError("LevelID", "等级不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.RegMoney.ToString()))
            {
                ModelState.AddModelError("RegMoney", "注册金额不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.RecommendCode))
            {
                ModelState.AddModelError("RecommendCode", "推荐人不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.ParentCode))
            {
                ModelState.AddModelError("ParentCode", "安置会员不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.Location.ToString()))
            {
                ModelState.AddModelError("Location", "安置区域不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.TrueName))
            {
                ModelState.AddModelError("TrueName", "会员姓名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(model.PhoneNum))
            {
                ModelState.AddModelError("PhoneNum", "手机号码不能为空");
                return;
            }
        }

        public string RegMoney()
        {
            if (Request.Params["id"] == "1")
            {
                return "100";
            }
            else if (Request.Params["id"] == "2")
            {
                return "200";
            }
            else
            {
                return "0";
            }
        }
        #endregion
        public ActionResult PersonalInfo()
        {
            UserDTO model = UserServer.GetModel(9);
            LevelDTO lvel = lvelname.GetLevelName(model.LevelID);
            ViewBag.BankModelList = brank.GetAllList();
            if (lvel != null)
            {
                model.LevelName = lvel.LevelName;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifitLoginInfo(UserDTO model)
        {
            string msg = "";
            bool bol = UserServer.UpdateLoginInfo(model);
            if (bol)
            {
                msg = "修改成功";
            }
            else
            {
                msg = "修改失败";
            }
            return Content("<script>alert('" + msg + "');window.location='/Team/PersonalInfo';</script>");
        }
        [HttpPost]
        public ActionResult ModifitLoginPwd(UserDTO model)
        {
            string msg = "";
            UserDTO usermodel = UserServer.GetModel(model.ID);
            if(Request.Params["repwd"]!= model.Password)
            {
                msg = "密码不一致";
            }else if(usermodel.Password!= CommonHelper.GetMD5(Request.Params["oldpwd"]))
            {
                msg = "旧密码不正确";
            }
            else if (CommonHelper.GetMD5(model.Password)== usermodel.Password)
            {
                msg = "新密码不能于旧密码一样，请重新输入新的密码";
            }
            else
            {
                model.Password = CommonHelper.GetMD5(model.Password);
                bool bol = UserServer.UpdateLogPwd(model);
                if (bol)
                {
                    msg = "修改成功";
                }
                else
                {
                    msg = "修改失败";
                }
            }
           
            return Content("<script>alert('" + msg + "');window.location='/Team/PersonalInfo';</script>");
        }
        [HttpPost]
        public ActionResult ModifitSecodePwd(UserDTO model)
        {
            string msg = "";
            UserDTO usermodel = UserServer.GetModel(model.ID);
            if (Request.Params["resepwd"] != model.SecondPassword)
            {
                msg = "密码不一致";
            }
            else if (usermodel.SecondPassword != CommonHelper.GetMD5(Request.Params["oldsepwd"]))
            {
                msg = "旧密码不正确";
            }
            else if (CommonHelper.GetMD5(model.SecondPassword) == usermodel.SecondPassword)
            {
                msg = "新密码不能于旧密码一样，请重新输入新的密码";
            }
            else
            {
                model.SecondPassword = CommonHelper.GetMD5(model.SecondPassword);
                bool bol = UserServer.UpdateScodePwd(model);
                if (bol)
                {
                    msg = "修改成功";
                }
                else
                {
                    msg = "修改失败";
                }
            }

            return Content("<script>alert('" + msg + "');window.location='/Team/PersonalInfo';</script>");
        }
        [HttpPost]
        public ActionResult ModifitBaseInfo(UserDTO model)
        {
            string msg = "";
            //model.SecondPassword = GetMd5(model.SecondPassword);
            //string bname = Request.Params["BankName"];
            bool bol = UserServer.UpdateBaseInfo(model);
            if (bol)
            {
                msg = "修改成功";
            }
            else
            {
                msg = "修改失败";
            }
            return Content("<script>alert('" + msg + "');window.location='/Team/PersonalInfo';</script>");
        }
        public ActionResult RecommendTree()
        {
            return View();
        }
        #region 加载tree节点
        /// <summary>
        /// 加载tree节点
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string TreeMethod(int uid,string id)
        {

            StringBuilder sb = new StringBuilder();
            //int uid = Convert.ToInt32(Request.QueryString["uid"]);
            if (id != "#")
            {
                uid = int.Parse(id);
            }
            UserDTO us = UserServer.GetModel(uid);

            //string treeTxte = "";0

            //if (root)
            //{
            IList<UserDTO> list = UserServer.GetRecommendModelList(us.ID);
            string treeTxte = Treetext(uid);
            if (id == "#")
            {
                sb.Append("\"text\":\"" + treeTxte + "\",\"expanded\":\"false\",\"state\":{\"opened\":\"true\"}");
            }
            if(list.Count > 0)
            {
                if (id == "#")
                {
                    sb.Append(",\"children\":[{");
                }
           
                for (int i = 0; i < list.Count; i++)
                {
                    // sb.Append(TreeMethod(Convert.ToInt32(list[i].ID)));
              
                    IList<UserDTO> list2 = UserServer.GetRecommendModelList(list[i].ID);
                    if (list2.Count > 0)
                    {
                        sb.Append("\"text\":\"" + Treetext(Convert.ToInt32(list[i].ID)) + "\",\"children\":true,\"id\":\"" + list[i].ID + "\"");
                    }
                    else
                    {
                        sb.Append("\"text\":\"" + Treetext(Convert.ToInt32(list[i].ID)) + "\"");
                    }

                    if (i != list.Count - 1)
                    {
                        sb.AppendLine("},{");
                    }
                }
                if (id == "#")
                {
                    sb.Append("}]");
                }
            }
            return "[{" + sb.ToString() + "}]";
        }
        public string Treetext(int uid)
        {
            string treeTxte = "";
            UserDTO Model = new UserDTO();
            //AllCore allcore = new AllCore();
            if (UserServer.GetModel(uid) == null)
            {
                return null;
            }
            Model = UserServer.GetModel(uid);
            string LevelName = "";
            if (Model.LevelID == 0)
            {
                LevelName = "无等级";
            }
            else
            {
                LevelName = lvelname.GetLevelName(Model.LevelID).LevelName;
            }

            string dd = "";
            // decimal allEmoney = 0;
            // allEmoney =userBLL.GetEmeony(uid);
            if (Model.IsOpend == 0)
            {
                dd = "[<span style='color:red;'>未开通</span>]";
            }
            else if (Model.IsOpend == 2)
            {
                dd = "已开通";
            }
            if (uid == 2)
            {
                return null;
            }
            else
            {
                string enlevel = "", saleLevel = "";
                if (Model.LevelID == 0)
                {
                    enlevel = "无等级";
                }
                else
                {
                    enlevel = lvelname.GetLevelName(Model.LevelID).LevelName;
                }
                treeTxte = Model.UserCode + "[" + Model.TrueName + "] " + dd + " [" + enlevel + "] " + saleLevel + "- 市场业绩：" + (Model.LeftScore + Model.RightScore);
                    
                    //treeTxte = Model.UserCode + "[姓名：" + Model.TrueName + " | 级别：" + enlevel + " | 状态：" + dd + "";
                
                //node.NavigateUrl = "RecommendTree.aspx?userid=" + Model.UserID;
            }
            return treeTxte;
        }
        public string TreeSeachMethod(string code,string id)
        {
            UserDTO us = new UserDTO();
            if (code != "")
            {
                us = UserServer.GetModelCode(code);
            }
            else
            {
                us = UserServer.GetModelCode("system");
            }
          
            return TreeMethod(int.Parse(us.ID.ToString()), id);
        }
        #endregion
    }
}