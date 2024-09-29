using Backend.Models.City_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ICityService
    {
        List<City> Get();
        City GetById(int id);
        void Create(City city);
        void Update(City city);
        void Delete(int id);
    }
}
