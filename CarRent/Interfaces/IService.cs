using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Interfaces
{
    public interface IService<TModel, Tsearch>
    {
        List<TModel> Get(Tsearch search);
        TModel GetByID(int id);
    }
}
