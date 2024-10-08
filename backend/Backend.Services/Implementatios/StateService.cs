using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Context.Models;
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.State_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class StateService : IStateService
    {
        private readonly IStateRepo _stateRepo;
        public StateService(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;   
        }
        public async Task<State>Create(State state)
        {
            if (state== null) throw new ArgumentNullException("state");
            else
            {
               var res=await _stateRepo.Create(state.fromStateToTblState());
                if (res != null)
                {

                    var state_mod = res.fromtblToState();
                    return state_mod;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<State>Delete(long id)
        {
            var res=await _stateRepo.Delete(id);
            return res.fromtblToState() ;
        }

        public async Task<State>Get(long id)
        {
            
                var res=await _stateRepo.Get(id);

            return res.fromtblToState();
        }

        public async Task<List<State>> GetAll()
        {
            List <TblState> listtbl=await _stateRepo.GetAll();
            List<State> _state = listtbl.Select(x => x.fromtblToState()).ToList();
            return _state;
        }

        public async Task<State>Update(State state, long id)
        {
          var res= await _stateRepo.Update(state.fromStateToTblState(), id);
            return res.fromtblToState();

        }
    }
}
