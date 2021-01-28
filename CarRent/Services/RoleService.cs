using AutoMapper;
using CarRent.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class RoleService : BaseCRUDService<Model.Role, Model.Requests.Role.RoleSearchRequest, Database.Role, Model.Requests.Role.RoleInsert, Model.Requests.Role.RoleInsert>
    {
        public RoleService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
