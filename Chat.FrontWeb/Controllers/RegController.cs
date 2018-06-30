using Chat.Service.Entities;
using Chat.WebCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Service;
using Chat.IService.Interface;

namespace Chat.FrontWeb.Controllers
{
    public class RegController : Controller
    {
        // GET: Reg
        public   IRegister IRegister { get;set; }
        public ActionResult Register()
        {
            return View();
        }
        public static string GetMd5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        }
        public ActionResult Zuce()
        {
            var User1= IRegister.DS("");
          var User=IRegister.UserDTO(9);
          


            if (RegValidate())
            {
                
                //UserEntity m_user = new UserEntity();
                //m_user.UserCode = txtUserCode.Value.Trim();//会员编号
                //UserEntity ModelRecommend = 
                //m_user.RecommendID = ModelRecommend.UserID;//推荐人ID
                //m_user.RecommendCode = ModelRecommend.UserCode;//推荐人编号
                //m_user.RecommendPath = ModelRecommend.RecommendPath; //路径
                //m_user.RecommendGenera = Convert.ToInt32(ModelRecommend.RecommendGenera + 1);//（推荐代数）第几代
                //                                                                             // return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString()
                //m_user.ParentID = long.Parse(param.Split(',')[0]);//父节点ID
                //m_user.ParentCode = param.Split(',')[1];//父节点編號
                //m_user.UserPath = param.Split(',')[2]; //路径
                //m_user.Layer = int.Parse(param.Split(',')[3]) + 1;//属于多少层 
                //m_user.LevelID = 0; 
                //m_user.RecommendID = getLoginID();
                //m_user.Location = int.Parse(param.Split(',')[4]); 
                ////Convert.ToInt32(DrLocation.SelectedValue); 
                //m_user.RegTime = DateTime.Now;//注册時間
                //m_user.OpenTime = DateTime.Now;
                //m_user.BillCount = 1;// getParamInt("reg" + ddlLevel.SelectedValue);//注册单数
                //m_user.Password = GetMd5(this.txtPassword.Value.Trim());//一级密码
                //m_user.SecondPassword = "";//PageValidate.GetMd5(this.txtSecondPassword.Value.Trim());//二级密码
                //m_user.ThreePassword = "";// PageValidate.GetMd5(this.txtThreePassword.Value.Trim());//三级密码

                //m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                //m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                //m_user.BankName = this.dropBank.SelectedItem.Text;// "開户銀行";
                //m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                //m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                //m_user.BankInCity = "";//DropDownList1.SelectedItem.Text;// "銀行所在城市";  
                //m_user.Gender = 1;//男 
                //m_user.NiceName = string.Empty;//txtNickName.Value.Trim();//昵称
                //m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                //m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
                //string phoneNum = txtUserCode.Value.Trim();
                //m_user.PhoneNum = string.IsNullOrEmpty(phoneNum) ? "" : phoneNum;// "手机號碼";
                //m_user.Address = txtAddress.Value;//聯系地址
                //m_user.User002 = getLoginID();//
                //m_user.SafetyCodeQuestion = "";// dropQuestion.SelectedItem.Text;// question;//密保问题
                //m_user.SafetyCodeAnswer = "";// txtAnswer.Value.Trim();//密保答案
                return Json( new AjaxResult { Msg="注册成功!"});
            }
            return Json(new AjaxResult { Msg = "注册失败!" });
        }
        public bool RegValidate()
        {

            return false;
        }
        /// <summary>
        /// 落点
        /// </summary>
        /// <returns></returns>
        //private string Get_LuoDian()
        //{ 

        //    string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"]; 

        //   var model = userBLL.GetModel(getLoginID());
        //    if (model != null)
        //    {
        //        if (model.LeftScore <= model.RightScore)//左区优先(小区) //第一次左区 Location= 1
        //        {
        //            #region 第一次左区 Location= 1   ParentID=UserID, ParentCode=usercode , UserPath=UserPath , Layer =Layer
        //            string sql = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where ParentID='" + getLoginID() + "' and Location= 1;select UserID from tb_user ;select userID,Location from tb_user where ParentID='" + getLoginID() + "'";
                  
        //            DataSet ds = userBLL.getData_Chaxun(sql, "");
        //            DataTable DT = new DataTable();
        //            DataTable dt = new DataTable();
        //            DataTable Dt = new DataTable();
        //            dt = ds.Tables[0];
        //            DT = ds.Tables[1];
        //            Dt = ds.Tables[2];

        //            string UserID = "";
        //            int count = Dt.Rows.Count;
        //            if (count == 0)
        //            {
        //                return model.UserID + "," + model.UserCode + "," + model.UserPath + "," + model.Layer + ",1";
        //            }

        //            if (count == 1)
        //            {
        //                return model.UserID + "," + model.UserCode + "," + model.UserPath + "," + model.Layer + ",2";
        //            }
        //            decimal LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //            decimal RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());

        //            #region 第二次左区 Location= 1
        //            if (count == 2)
        //            {
        //                if (LeftScore <= RightScore)
        //                {
        //                    UserID = dt.Rows[0]["userID"].ToString();
        //                    for (int i = 0; i < count + i; i++)
        //                    {
        //                        string sql_1 = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where UserID='" + UserID + "';select userID,Location from tb_user where ParentID='" + UserID + "' order by Location asc";
        //                        DataSet ds_1 = userBLL.getData_Chaxun(sql_1, "");
        //                        dt = ds_1.Tables[0];
        //                        DT = ds_1.Tables[1];
        //                        int Location = DT.Rows.Count;
        //                        LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //                        RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());
        //                        if (Location == 2)
        //                        {
        //                            if (LeftScore <= RightScore)
        //                            {
        //                                UserID = DT.Rows[0]["userID"].ToString();
        //                                continue;
        //                            }
        //                            else
        //                            {
        //                                UserID = DT.Rows[1]["userID"].ToString();
        //                                continue;
        //                            }
        //                        }
        //                        else if (Location == 1)
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";
        //                        }
        //                        else
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    UserID = dt.Rows[0]["userID"].ToString();//右区小的UserID
        //                    for (int i = 0; i < count + i; i++)
        //                    {
        //                        string sql_1 = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where UserID='" + UserID + "';select userID,Location from tb_user where ParentID='" + UserID + "' order by Location asc";
        //                        DataSet ds_1 = userBLL.getData_Chaxun(sql_1, "");
        //                        dt = ds_1.Tables[0];
        //                        DT = ds_1.Tables[1];
        //                        int Location = DT.Rows.Count;
        //                        LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //                        RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());
        //                        if (Location == 2)
        //                        {
        //                            if (LeftScore <= RightScore)
        //                            {
        //                                UserID = DT.Rows[0]["userID"].ToString();
        //                                continue;
        //                            }
        //                            else
        //                            {
        //                                UserID = DT.Rows[1]["userID"].ToString();
        //                                continue;
        //                            }
        //                        }
        //                        else if (Location == 1)
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";
        //                        }
        //                        else
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //                        }

        //                    }
        //                }
        //            }
        //            #endregion
        //            else if (count == 1)
        //            {

        //                return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";

        //            }
        //            else
        //            {
        //                return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //            }
        //            #endregion
        //        }
        //        else//第一次右区 Location= 2
        //        {
        //            string sql = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where ParentID='" + getLoginID() + "' and Location= 2;select UserID from tb_user  ;select userID,Location from tb_user where ParentID='" + getLoginID() + "'";
        //            DataSet ds = userBLL.getData_Chaxun(sql, "");
        //            DataTable DT = new DataTable();
        //            DataTable dt = new DataTable();
        //            DataTable Dt = new DataTable();
        //            dt = ds.Tables[0];
        //            DT = ds.Tables[1];
        //            Dt = ds.Tables[2];
        //            string UserID = "";
        //            int count = Dt.Rows.Count;
        //            if (count == 0)
        //            {
        //                return model.UserID + "," + model.UserCode + "," + model.UserPath + "," + model.Layer + ",1";
        //            }
        //            if (count == 1)
        //            {
        //                return model.UserID + "," + model.UserCode + "," + model.UserPath + "," + model.Layer + ",2";
        //            }
        //            decimal LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //            decimal RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());

        //            if (count == 2)
        //            {
        //                if (LeftScore <= RightScore)
        //                {
        //                    UserID = dt.Rows[0]["userID"].ToString();
        //                    for (int i = 0; i < count + i; i++)
        //                    {
        //                        string sql_1 = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where UserID='" + UserID + "';select userID,Location from tb_user where ParentID='" + UserID + "' order by Location asc";
        //                        DataSet ds_1 = userBLL.getData_Chaxun(sql_1, "");
        //                        dt = ds_1.Tables[0];
        //                        DT = ds_1.Tables[1];
        //                        int Location = DT.Rows.Count;
        //                        LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //                        RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());
        //                        if (Location == 2)
        //                        {
        //                            if (LeftScore <= RightScore)
        //                            {
        //                                UserID = DT.Rows[0]["userID"].ToString();
        //                                continue;
        //                            }
        //                            else
        //                            {
        //                                UserID = DT.Rows[1]["userID"].ToString();
        //                                continue;
        //                            }
        //                        }
        //                        else if (Location == 1)
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";
        //                        }
        //                        else
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    UserID = dt.Rows[0]["userID"].ToString();//右区小的UserID
        //                    for (int i = 0; i < count + i; i++)
        //                    {
        //                        string sql_1 = "select UserID,LeftScore,RightScore,UserPath,usercode,Layer from tb_user where UserID='" + UserID + "';select userID,Location from tb_user where ParentID='" + UserID + "' order by Location asc";
        //                        DataSet ds_1 = userBLL.getData_Chaxun(sql_1, "");
        //                        dt = ds_1.Tables[0];
        //                        DT = ds_1.Tables[1];
        //                        int Location = DT.Rows.Count;
        //                        LeftScore = decimal.Parse(dt.Rows[0]["LeftScore"].ToString());
        //                        RightScore = decimal.Parse(dt.Rows[0]["RightScore"].ToString());
        //                        if (Location == 2)
        //                        {
        //                            if (LeftScore <= RightScore)
        //                            {
        //                                UserID = DT.Rows[0]["userID"].ToString();
        //                                continue;
        //                            }
        //                            else
        //                            {
        //                                UserID = DT.Rows[1]["userID"].ToString();
        //                                continue;
        //                            }
        //                        }
        //                        else if (Location == 1)
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";
        //                        }
        //                        else
        //                        {
        //                            return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //                        }

        //                    }
        //                }
        //            }
        //            else if (count == 1)
        //            {

        //                return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",2";

        //            }
        //            else
        //            {
        //                return dt.Rows[0]["UserID"].ToString() + "," + dt.Rows[0]["usercode"].ToString() + "," + dt.Rows[0]["UserPath"].ToString() + "," + dt.Rows[0]["Layer"].ToString() + ",1";
        //            }
        //        }
        //    }
        //    return "";
        //}
    }
}