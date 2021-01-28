using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Model;
using CarRent.Model.Requests.City;

namespace CarRent.WebApi.Services
{
    public class CityService : BaseService<Model.City, Model.Requests.City.CitySearchRequest, Database.City>
    {
        public CityService(Database.CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<City> Get(CitySearchRequest search)
        {
            var query = _context.Cities.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search.CityName))
            {
                query = query.Where(w => w.Name.StartsWith(search.CityName));
            }

            if(search.CityId != null)
            {
                query = query.Where(w => w.Id == search.CityId);
            }

            return _mapper.Map<List<Model.City>>(query.ToList());
        }
    }
}
