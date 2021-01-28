using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class BrandService : BaseService<Model.Brand, Model.Requests.Brand.BrandSearchRequest, Database.Brand>
    {
        public BrandService(Database.CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
