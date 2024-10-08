using Backend.Models.State_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IStateService
    {
        Task<List<State>> GetAll();
        Task<State> Get(long id);
        Task<State> Create(State state);
        Task<State> Update(State state, long id);
        Task<State> Delete(long id);
    }
}
