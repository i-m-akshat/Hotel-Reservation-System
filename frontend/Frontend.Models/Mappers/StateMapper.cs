using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models.Mappers
{
    public static class StateMapper
    {
        public static State_Model FromDTOToModel(this State_DTO dto)
        {
            return new State_Model
            {
                StateId = dto.stateid,
                StateName = dto.statename,
                CountryId = dto.countryid,
                CountryName=dto.countryname,
            };
        }
    }
}
