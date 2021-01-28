using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : BaseCRUDController<Model.VehicleModel, Model.Requests.VehicleModel.VehicleModelSearchRequest, Model.Requests.VehicleModel.VehicleModelInsert, Model.Requests.VehicleModel.VehicleModelInsert>
    {
        public VehicleModelController(ICRUDService<Model.VehicleModel, Model.Requests.VehicleModel.VehicleModelSearchRequest, Model.Requests.VehicleModel.VehicleModelInsert, Model.Requests.VehicleModel.VehicleModelInsert> service) : base(service)
        {
        }
    }
}
