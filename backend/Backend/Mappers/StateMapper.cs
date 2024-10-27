using Backend.DTO.State;
using Backend.Models.State_Domain;

namespace Backend.Mappers
{
    public static class StateMapper
    {
        public static State ToStateFromDTO(this State_DTO dto)
        {
            return new State
            {
                StateId=dto.stateid,
                StateName=dto.statename,
                CountryId=dto.countryid,    

            };
        }
        public static State ToStateFromDTO_Create(this State_DTO dto)
        {
            return new State
            {
                
                StateName = dto.statename,
                CountryId = dto.countryid,

            };
        }

        public static State_DTO ToDtoFromState(this State state) {

            return new State_DTO
            {
                stateid=state.StateId,
                countryid=state.CountryId,
                statename=state.StateName,
                
            };
        }
        public static State_DTO_GetAll ToDtoFromState_All(this State state)
        {
            return new State_DTO_GetAll
            {
                stateid = state.StateId,
                countryid = state.CountryId,
                statename = state.StateName,
                countryname=state.CountryName
            };
        }
    }
}
