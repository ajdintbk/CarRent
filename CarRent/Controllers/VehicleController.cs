using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model;
using CarRent.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRent.Model.Requests.Vehicle;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : BaseCRUDController<Model.Vehicle, VehicleSearchRequest, VehicleInsert, VehicleInsert>
    {
        private readonly ICRUDService<Vehicle, VehicleSearchRequest, VehicleInsert, VehicleInsert> _service;
        public VehicleController(ICRUDService<Vehicle, VehicleSearchRequest, VehicleInsert, VehicleInsert> service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
