using AutoMapper;
using CarRent.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class FuelService : BaseService<Model.Fuel, Model.Requests.Fuel.FuelSearchRequest, Database.Fuel>
    {
        public FuelService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
