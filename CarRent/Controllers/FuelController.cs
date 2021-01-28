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
    public class FuelController : BaseController<Model.Fuel, Model.Requests.Fuel.FuelSearchRequest>
    {
        public FuelController(IService<Model.Fuel, Model.Requests.Fuel.FuelSearchRequest> service) : base(service)
        {
        }
    }
}
