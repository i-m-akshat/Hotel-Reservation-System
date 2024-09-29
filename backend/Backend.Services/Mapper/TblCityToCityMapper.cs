using Backend.Models.City_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DataAccessLayer.Context.Models;

namespace Backend.Services.Mapper
{
   public static class TblCityToCityMapper
    {

        public static City ToCityModel(this TblCity city)
        {
            return new City
            {
                CityId = city.CityId,
                CityName = city.CityName,  
                StateId = city.StateId
            };
        }

    }
}
