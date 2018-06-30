using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Service
{
    public class Register: IRegister
    { 
        public DataSet DS (string sql)
        {
            using (MyDbContext db= new MyDbContext())
            {
             
               

                DataSet ds = new DataSet();
                //var ds = db.User.SqlQuery<UserEntity>(sql, new SqlParameter());
                var peopleViews = db.User.SqlQuery("SELECT * FROM tb_user").ToList();
                var peopleViewss = db.Database.SqlQuery<UserEntity>("SELECT * FROM tb_user ");
               
                //var ds1 = db.User.SqlQuery(sql).ToList();
                return ds;

            }
              
        }
      public UserResult UserDTO(int ID)
        {
            using (MyDbContext db = new MyDbContext())
            {
                UserResult User = new UserResult();
                UserEntity U = new UserEntity();

                //U = db.User.Where(p => p.ID == ID).Select(p=> new UserEntity {ID=p.ID }).SingleOrDefault();
                var a = db.User.Where(p => p.ID == ID).ToArray().AsQueryable();
                var s = a.ToList().ToArray();
           
                  var b = db.User.Where(p => p.ID == ID).OrderByDescending(p => p.ID == ID);
                User.UserListDTO = db.User.Where(p => p.ID == ID).ToList().Select(p=>ToDTO(p));


                return User;
            }
        }
        public UserDTO ToDTO(UserEntity model)
        {
            UserDTO dto = new UserDTO();

            dto.UserCode = model.UserCode;
            dto.AddGLTime = model.AddGLTime;
            dto.AgentsID = model.AgentsID;
            dto.Address = model.Address;
            dto.AllBonusAccount = model.AllBonusAccount;
            dto.BankAccount = model.BankAccount;
            dto.BankAccountUser = model.BankAccountUser;
            dto.BankBranch = model.BankBranch;
            dto.BankInCity = model.BankInCity;
            dto.BankInProvince = model.BankInProvince;
            dto.BankName = model.BankName;
            dto.BillCount = model.BillCount;
            dto.BonusAccount = model.BonusAccount;
            dto.CenterBalance = model.CenterBalance;
            dto.CenterNewScore = model.CenterNewScore;
            dto.CenterScore = model.CenterScore;
            dto.CenterZT = model.CenterZT;
            dto.CreateTime = model.CreateTime;
            dto.Emoney = model.Emoney;
            dto.Gender = model.Gender;
            dto.GLmoney = model.GLmoney;
            dto.ID = model.ID;
            dto.IdenCode = model.IdenCode;
            dto.IsAgent = model.IsAgent;
            dto.IsLock = model.IsLock;
            dto.IsOpend = model.IsOpend;
            dto.Layer = model.Layer;
            dto.LeftBalance = model.LeftBalance;
            dto.LeftNewScore = model.LeftNewScore;
            dto.LeftScore = model.LeftScore;
            dto.LeftZT = model.LeftZT;
            dto.LevelID = model.LevelID;
            dto.Location = model.Location;
            dto.NiceName = model.NiceName;
            dto.OpenTime = model.OpenTime;
            dto.ParentCode = model.ParentCode;
            dto.ParentID = model.ParentID;
            dto.Password = model.Password;
            dto.PhoneNum = model.PhoneNum;
            dto.QQnumer = model.QQnumer;
            dto.RecommendCode = model.RecommendCode;
            dto.RecommendGenera = model.RecommendGenera;
            dto.RecommendID = model.RecommendID;
            dto.RecommendPath = model.RecommendPath;
            dto.RegMoney = model.RegMoney;
            dto.RegTime = model.RegTime;
            dto.RightBalance = model.RightBalance;
            dto.RightNewScore = model.RightNewScore;
            dto.RightScore = model.RightScore;
            dto.RightZT = model.RightZT;
            dto.SafetyCodeAnswer = model.SafetyCodeAnswer;
            dto.SafetyCodeQuestion = model.SafetyCodeQuestion;
            dto.SecondPassword = model.SecondPassword;
            dto.ShopAccount = model.ShopAccount;
            dto.StockAccount = model.StockAccount;
            dto.StockMoney = model.StockMoney;
            dto.ThreePassword = model.ThreePassword;
            dto.TrueName = model.TrueName;
            dto.User001 = model.User001;
            dto.User002 = model.User002;
            dto.User003 = model.User003;
            dto.User004 = model.User004;
            dto.User005 = model.User005;
            dto.User006 = model.User006;
            dto.User007 = model.User007;
            dto.User008 = model.User008;
            dto.User009 = model.User009;
            dto.User010 = model.User010;
            dto.User011 = model.User012;
            dto.User013 = model.User013;
            dto.User014 = model.User014;
            dto.User015 = model.User015;
            dto.User016 = model.User016;
            dto.User017 = model.User017;
            dto.User018 = model.User018;
            dto.User012 = model.User012;
            dto.UserPath = model.UserPath;
            return dto;
        }

    }
}
