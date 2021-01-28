using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model;
using CarRent.Model.Requests.City;
using CarRent.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    public class CityController : BaseController<Model.City, Model.Requests.City.CitySearchRequest>
    {
        public CityController(IService<City, CitySearchRequest> service) : base(service)
        {
        }
    }
}
