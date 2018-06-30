﻿using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chat.IService.Interface.INewsService;

namespace Chat.Service.Service
{
    public class NewsService : INewsService
    {
        #region 添加新闻公告
        /// <summary>
        /// 添加新闻公告
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>

        /// <returns></returns>
        public long Add(string Title, int dropNewType, string Context, DateTime Time)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                NewsEntity newsModel = new NewsEntity();

                newsModel.NewsTitle = Title;
                newsModel.NewsContent = Context;
                newsModel.NewType = dropNewType;
                newsModel.PublishTime = Time;

                dbcontext.News.Add(newsModel);
                dbcontext.SaveChanges();
                return newsModel.ID;
            }

        }
        #endregion
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<NewsDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<NewsEntity> csr = new CommonService<NewsEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion 

        public NewsPageResult GetPageList(int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<NewsEntity> csr = new CommonService<NewsEntity>(dbcontext);
                NewsPageResult PageResult = new NewsPageResult();
                var NewsQuery = csr.GetAll();
                PageResult.TotalCount = NewsQuery.LongCount();
                PageResult.News = NewsQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return PageResult;
            }
        }
        public NewsDTO ToDTO(NewsEntity msg)
        {
            NewsDTO news = new NewsDTO();
            news.ID = msg.ID;
            news.NewsTitle = msg.NewsTitle;
            news.PublishTime = msg.PublishTime;
            news.NewType = (int)msg.NewType;

            return news;
        }
        /// <summary>
        /// 根据ID查询用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public NewsDTO GetModel(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                NewsEntity r = cs.GetById(Id);
                if (r != null)
                {
                    return new NewsDTO
                    {
                        NewsTitle = r.NewsTitle,
                        PublishTime = r.PublishTime,
                        NewType = r.NewType == null ? 0 : (int)r.NewType,
                        NewsType = r.NewsType,
                        Publisher = string.IsNullOrWhiteSpace(r.Publisher) ? "" : r.Publisher,
                        ImageURL = r.ImageURL,
                        Classify = r.Classify,
                        Tags = r.Tags,
                        Click = r.Click == null ? 0 : (int)r.Click,
                        New01 = r.New01 == null ? 0 : (int)r.New01,
                        New02 = r.New02 == null ? 0 : (int)r.New02,
                        New03 = r.New03 == null ? 0 : (decimal)r.New03,
                        New04 = r.New04 == null ? 0 : (decimal)r.New04,
                        New05 = string.IsNullOrWhiteSpace(r.New05) ? "" : r.New05,
                        New06 = string.IsNullOrWhiteSpace(r.New06) ? "" : r.New06,
                        CreateTime = r.CreateTime,
                        NewsContent = r.NewsContent,
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public bool Update(NewsDTO hh)
        {
            using (MyDbContext dbc = new MyDbContext())
            {

                CommonService<NewsEntity> acs = new CommonService<NewsEntity>(dbc);
                NewsEntity news = acs.GetAll().SingleOrDefault(a => a.ID == hh.ID);
                news.NewsTitle = hh.NewsTitle;
                news.NewsContent = hh.NewsContent;
                news.PublishTime = hh.PublishTime;
                news.NewType = hh.NewType;

                dbc.SaveChanges();
                return true;
            }
        }
        //前台新闻公告列表
        /// <summary>
        /// 前台查询未开通会员
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="GetLoginID">GetLoginID 推荐会员</param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="i">i=0就是查询未开通会员 2 是开通会员   3是注册会员</param>
        /// <returns></returns>
        public NewsPageResult GetNewsList(int NewType,string Title, DateTime? Strat, DateTime? End, int PageIndex, int PageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {

                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                NewsPageResult NewsSearch = new NewsPageResult();
                var naws = cs.GetAll();

                if (Strat != null)
                {
                    naws = naws.Where(p => p.CreateTime >= Strat);
                }
                if (End != null)
                {
                    naws = naws.Where(p => p.CreateTime <= End);
                  

                }
                if (NewType > 0)
                {
                    naws = naws.Where(p => p.NewType == NewType);
                }

                if (Title != "")
                {
                 naws = naws.Where(p => p.NewsTitle.Contains(Title));

                 }
                    NewsSearch.TotalCount = naws.LongCount();
                    NewsSearch.News = naws.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                    return NewsSearch;
                }
            }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="hh"></param>
        /// <returns></returns>
        public int AddTypeName( NewsTypeDTO hh)
        {
            using (MyDbContext dbc = new MyDbContext())
            { 
                NewsTypeEntity Type = new NewsTypeEntity(); 
                Type.NewTypeName = hh.NewTypeName; 
                dbc.NewsType.Add(Type);
                dbc.SaveChanges();
                return 2;
            }
        }
        /// <summary>
        /// 获取新闻Type名字
        /// </summary>
        /// <returns></returns>
        public NewsPageResult getdata()
        {
            using (MyDbContext dbc = new MyDbContext())
            {

                CommonService<NewsTypeEntity> cs = new CommonService<NewsTypeEntity>(dbc);
                var user = cs.GetAll(); 
                NewsPageResult Result = new NewsPageResult();
              
                Result.NewsTypeList = user.ToList().Select(p => NewsType(p)).ToArray(); 
                return Result;
            } 
        }
        /// <summary>
        /// 删除或者修改类型 0删除 1修改
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Del(long ID,int type , string name)
        {
            using (MyDbContext dbc = new MyDbContext())
            { 
                CommonService<NewsTypeEntity> cs = new CommonService<NewsTypeEntity>(dbc);
                var user = cs.GetById(ID);
                if (user==null)
                {
                    return 0;
                }
                if (type==0)
                {
                    user.IsDeleted = true;
                    dbc.SaveChanges();
                    return 2;
                }
                if (type==1)
                {
                    user.NewTypeName = name;
                    dbc.SaveChanges();
                    return 2;
                }
                return 0;


            } 
        }
        public NewsTypeDTO NewsType (NewsTypeEntity user)
        {
            NewsTypeDTO NewsType = new NewsTypeDTO();
            NewsType.ID = user.ID;
            NewsType.NewTypeName = user.NewTypeName;  
            return NewsType;
        }


    }
   }
  

