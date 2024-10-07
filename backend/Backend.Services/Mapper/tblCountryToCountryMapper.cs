using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Country_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class tblCountryToCountryMapper
    {
        public static Country toCountry(this TblCountry _tbl)
        {
            return new Country
            {
                CountryName = _tbl.CountryName,
                CountryId = _tbl.CountryId, 
            };
        }
        public static TblCountry ToTblCountry(this Country _country)
        {
            //if (_country == null)
            //{
                return new TblCountry {
                    CountryName=_country.CountryName,
                    
                };
            //}
            //else
            //{
            //    return null;
            //}
        }

    }
}
