using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model.Requests.Rent;
using CarRent.WebApi.Interfaces;
using CarRent.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRentService _service;
        public RentController(IRentService service)
        {
            _service = service;
        }

       
        [HttpPost]
        public ActionResult<Model.Rent> Insert(RentInsert request)
        {
            var rent = _service.Insert(request);
            if (rent == null)
            {
                return BadRequest("Vehicle is not available");
            }
            return rent;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<List<Model.Rent>> Get([FromQuery] RentSearchRequest request)
        {
            var rent = _service.Get(request);

            return rent;
        }

        [HttpGet("{id}")]
        public ActionResult<Model.Rent> Get(int id)
        {
            var rent = _service.GetById(id);

            return rent;
        }

        [HttpPut("{id}")]
        public ActionResult<Model.Rent> Update(int id, RentInsert request)
        {
            var rent = _service.Update(id, request);

            return rent;
        }
        [HttpGet("checkavailability")]
        public ActionResult<List<Model.Rent>> CheckAvailability([FromQuery] RentSearchRequest request)
        {
            var rent = _service.CheckAvailability(request);

            return rent;
        }

    }
}
