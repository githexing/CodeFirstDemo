using Chat.DTO.DTO;
using Chat.IService.Interface;
using Chat.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Service
{
    public class GoodsService : IGoodsService
    {
        public long Add(GoodsDTO dto)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                GoodsEntity goods = new GoodsEntity();
                goods.AddTime = dto.AddTime;
                goods.CreateTime = dto.CreateTime;
                goods.FLH1 = dto.FLH1;
                goods.FLH2 = dto.FLH2;
                goods.FLH3 = dto.FLH3;
                goods.FLJ1 = dto.FLJ1;
                goods.FLJ2 = dto.FLJ2;
                goods.FLJ3 = dto.FLJ3;
                goods.FLT1 = dto.FLT1;
                goods.FLT2 = dto.FLT2;
                goods.FLT3 = dto.FLT3;
                goods.Goods001 = dto.Goods001;
                goods.Goods002 = dto.Goods002;
                goods.Goods003 = dto.Goods003;
                goods.Goods004 = dto.Goods004;
                goods.Goods005 = dto.Goods005;
                goods.Goods006 = dto.Goods006;
                goods.Goods007 = dto.Goods007;
                goods.Goods008 = dto.Goods008;
                goods.GoodsCode = dto.GoodsCode;
                goods.GoodsName = dto.GoodsName;
                goods.GoodsName_en = dto.GoodsName_en;
                goods.GoodsType = dto.GoodsType;
                goods.IsHave = dto.IsHave;
                goods.Pic1 = dto.Pic1;
                goods.Pic2 = dto.Pic2;
                goods.Pic3 = dto.Pic3;
                goods.Pic4 = dto.Pic4;
                goods.Pic5 = dto.Pic5;
                goods.Price = dto.Price;
                goods.RealityPrice = dto.RealityPrice;
                goods.Remarks = dto.Remarks;
                goods.Remarks_en = dto.Remarks_en;
                goods.Standard = dto.Standard;
                goods.Summary = dto.Summary;
                goods.TypeID = dto.TypeID;
                dbc.Goods.Add(goods);
                dbc.SaveChanges();
                return goods.ID;
            }
        }

        public bool Update(GoodsDTO dto)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GoodsEntity> cs = new CommonService<GoodsEntity>(dbc);
                var goods=cs.GetAll().SingleOrDefault(g=>g.ID==dto.ID);
                if(goods==null)
                {
                    return false;
                }
                goods.AddTime = dto.AddTime;
                goods.CreateTime = dto.CreateTime;
                goods.FLH1 = dto.FLH1;
                goods.FLH2 = dto.FLH2;
                goods.FLH3 = dto.FLH3;
                goods.FLJ1 = dto.FLJ1;
                goods.FLJ2 = dto.FLJ2;
                goods.FLJ3 = dto.FLJ3;
                goods.FLT1 = dto.FLT1;
                goods.FLT2 = dto.FLT2;
                goods.FLT3 = dto.FLT3;
                goods.Goods001 = dto.Goods001;
                goods.Goods002 = dto.Goods002;
                goods.Goods003 = dto.Goods003;
                goods.Goods004 = dto.Goods004;
                goods.Goods005 = dto.Goods005;
                goods.Goods006 = dto.Goods006;
                goods.Goods007 = dto.Goods007;
                goods.Goods008 = dto.Goods008;
                goods.GoodsCode = dto.GoodsCode;
                goods.GoodsName = dto.GoodsName;
                goods.GoodsName_en = dto.GoodsName_en;
                goods.GoodsType = dto.GoodsType;
                goods.IsHave = dto.IsHave;
                goods.Pic1 = dto.Pic1;
                goods.Pic2 = dto.Pic2;
                goods.Pic3 = dto.Pic3;
                goods.Pic4 = dto.Pic4;
                goods.Pic5 = dto.Pic5;
                goods.Price = dto.Price;
                goods.RealityPrice = dto.RealityPrice;
                goods.Remarks = dto.Remarks;
                goods.Remarks_en = dto.Remarks_en;
                goods.Standard = dto.Standard;
                goods.Summary = dto.Summary;
                goods.TypeID = dto.TypeID;
                dbc.Goods.Add(goods);
                dbc.SaveChanges();
                return true;
            }
        }
        
        public bool Delete(long ID)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GoodsEntity> cs = new CommonService<GoodsEntity>(dbc);
                var goods=cs.GetAll().SingleOrDefault(g=>g.ID==ID);
                if(goods==null)
                {
                    return false;
                }
                goods.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }

        public GoodsDTO GetModel(long ID)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GoodsEntity> cs = new CommonService<GoodsEntity>(dbc);
                var goods = cs.GetAll().SingleOrDefault(g => g.ID == ID);
                if (goods == null)
                {
                    return null;
                }
                return ToDTO(goods);
            }
        }

        public SearchResult GetModelList(string goodsName, string goodsCode, DateTime? startTime, DateTime endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                SearchResult result = new SearchResult();
                CommonService<GoodsEntity> cs = new CommonService<GoodsEntity>(dbc);
                var goods = cs.GetAll();
                if(!string.IsNullOrEmpty(goodsName))
                {
                    goods = goods.Where(g=>g.GoodsName==goodsName);
                }
                if (!string.IsNullOrEmpty(goodsCode))
                {
                    goods = goods.Where(g => g.GoodsCode == goodsCode);
                }
                if (startTime!=null)
                {
                    goods = goods.Where(g => g.CreateTime >= startTime);
                }
                if (endTime != null)
                {
                    goods = goods.Where(g => g.CreateTime <= endTime);
                }
                result.TotalCount = goods.LongCount();
                result.Goods = goods.OrderByDescending(g => g.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(g => ToDTO(g)).ToArray();
                return result;
            }
        }
        public GoodsDTO ToDTO(GoodsEntity goods)
        {
            GoodsDTO dto = new GoodsDTO();
            dto.AddTime = goods.AddTime;
            dto.CreateTime = goods.CreateTime;
            dto.FLH1 = goods.FLH1;
            dto.FLH2 = goods.FLH2;
            dto.FLH3 = goods.FLH3;
            dto.FLJ1 = goods.FLJ1;
            dto.FLJ2 = goods.FLJ2;
            dto.FLJ3 = goods.FLJ3;
            dto.FLT1 = goods.FLT1;
            dto.FLT2 = goods.FLT2;
            dto.FLT3 = goods.FLT3;
            dto.Goods001 = goods.Goods001;
            dto.Goods002 = goods.Goods002;
            dto.Goods003 = goods.Goods003;
            dto.Goods004 = goods.Goods004;
            dto.Goods005 = goods.Goods005;
            dto.Goods006 = goods.Goods006;
            dto.Goods007 = goods.Goods007;
            dto.Goods008 = goods.Goods008;
            dto.GoodsCode = goods.GoodsCode;
            dto.GoodsName = goods.GoodsName;
            dto.GoodsName_en = goods.GoodsName_en;
            dto.GoodsType = goods.GoodsType;
            dto.IsHave = goods.IsHave;
            dto.Pic1 = goods.Pic1;
            dto.Pic2 = goods.Pic2;
            dto.Pic3 = goods.Pic3;
            dto.Pic4 = goods.Pic4;
            dto.Pic5 = goods.Pic5;
            dto.Price = goods.Price;
            dto.RealityPrice = goods.RealityPrice;
            dto.Remarks = goods.Remarks;
            dto.Remarks_en = goods.Remarks_en;
            dto.Standard = goods.Standard;
            dto.Summary = goods.Summary;
            dto.TypeID = goods.TypeID;
            dto.ID = goods.ID;
            return dto;
        }
    }
}
