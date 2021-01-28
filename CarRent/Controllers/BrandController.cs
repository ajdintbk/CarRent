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
    public class BrandController : BaseController<Model.Brand, Model.Requests.Brand.BrandSearchRequest>
    {
        public BrandController(IService<Model.Brand, Model.Requests.Brand.BrandSearchRequest> service) : base(service)
        {
        }
    }
}
