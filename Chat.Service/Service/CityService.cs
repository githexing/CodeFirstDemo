using Chat.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.DTO.DTO;
using Chat.Service;
using Chat.Service.Entities;

namespace Chat.Service.Service
{
    public class CityService : ICityService
    {
        public long AddNew(string cityId, string cityName, string cityEn, string father)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CityEntity city = new CityEntity();
                city.City = cityName;
                city.CityID = cityId;
                city.CityEn = cityEn;
                city.Father = father;
                dbc.City.Add(city);
                dbc.SaveChanges();
                return city.ID;
            }
        }

        public CityDTO[] GetAll()
        {
            throw new NotImplementedException();
        }

        public CityDTO GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
