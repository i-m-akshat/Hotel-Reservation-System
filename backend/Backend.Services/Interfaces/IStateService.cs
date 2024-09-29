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
        List<State> GetAll();
        State Get(int id);
        void Create(State state);
        void Update(State state);
        void Delete(int id);
    }
}
