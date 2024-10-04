using Backend.DataAccessLayer.Context.Models;
using Backend.Models.State_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class TblStateToStateMapper
    {
        public static TblState fromStateToTblState(this State _state)
        {
            if (_state == null) { throw new ArgumentNullException("state"); }
            else
            {
                return new TblState
                {
                    StateId= _state.StateId,   

                    CountryId= _state.CountryId,
                    StateName= _state.StateName,
                };
            }
        }
        public static State fromtblToState(this TblState _state) {
            return new State
            {
                StateName = _state.StateName,
                CountryId = _state.CountryId,
                StateId = _state.StateId,
                CountryName=_state.Country.CountryName,
            };
        
        }
    }
}
