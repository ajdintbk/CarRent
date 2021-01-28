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
    public class RoleController : BaseCRUDController<Model.Role, Model.Requests.Role.RoleSearchRequest, Model.Requests.Role.RoleInsert, Model.Requests.Role.RoleInsert>
    {
        public RoleController(ICRUDService<Model.Role, Model.Requests.Role.RoleSearchRequest, Model.Requests.Role.RoleInsert, Model.Requests.Role.RoleInsert> service) : base(service)
        {
        }
    }
}
