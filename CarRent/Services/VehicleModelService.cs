using AutoMapper;
using CarRent.Model.Requests.VehicleModel;
using CarRent.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class VehicleModelService : BaseCRUDService<Model.VehicleModel, Model.Requests.VehicleModel.VehicleModelSearchRequest, Database.VehicleModel, Model.Requests.VehicleModel.VehicleModelInsert, Model.Requests.VehicleModel.VehicleModelInsert>
    {
        public VehicleModelService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
