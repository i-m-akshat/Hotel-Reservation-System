﻿using Backend.Models.City_Domain;
using Backend.DataAccessLayer.Context.Models;

namespace Backend.Services.Mapper
{
   public static class TblCityToCityMapper
    {

        public static City_Model ToCityModel(this TblCity city)
        {
            return new City_Model
            {
                CityId = city.CityId,
                CityName = city.CityName,
                StateId = city.StateId,
                CountryId = city.CountryId,
                CountryName = city.Country.CountryName.ToString(),
                StateName = city.State.StateName.ToString()
            };
        }
        public static City_Model ToCityModel_withoutStateName(this TblCity city)
        {
            return new City_Model
            {
                CityId = city.CityId,
                CityName = city.CityName,
                StateId = city.StateId,
                CountryId=city.CountryId,
            };
        }
       
        public static TblCity ToTblCity(this City_Model city)
        {
            return new TblCity
            {
                CityName = city.CityName,
                StateId = city.StateId,
                CountryId = city.CountryId,
            };
        }
        public static City_Model ToCityModelWithState(this TblCity tblcity)
        {
            return new City_Model
            {
                CityId= tblcity.CityId,
                CityName = tblcity.CityName,
                StateId = tblcity.StateId,
                StateName=tblcity.State.StateName,
                CountryId = tblcity.CountryId,
                CountryName=tblcity.Country.CountryName,

            };
        }

        
    }
}
