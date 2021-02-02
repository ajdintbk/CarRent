using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model;
using CarRent.Model.Requests;
using CarRent.WebApi.Interfaces;
using CarRent.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserInterface _service;
        public UserController(IUserInterface service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<User>> Get([FromQuery]Model.Requests.User.UserSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Administrator, User")]
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public ActionResult<User> AddUser(AddUserRequest req)
        {
            if(_service.AddUser(req) != null)
            {
                return _service.AddUser(req);
            }
            else
            {
                return BadRequest("Username already exists.");
            }
        
        }
        [HttpPut("{id}")]
        public ActionResult<User> Update(int id, AddUserRequest req)
        {
            return _service.Update(id,req);

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Model.Requests.User.UserLoginRequest request)
        {
            var user = _service.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Email ili lozinka nisu ispravni!" });

            return Ok();
        }
    }
}
