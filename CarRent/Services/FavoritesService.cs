using AutoMapper;
using CarRent.Model.Requests.Favorites;
using CarRent.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class FavoritesService : BaseCRUDService<Model.Favorites, Model.Requests.Favorites.FavoritesSearchRequest, Database.Favorites, Model.Requests.Favorites.FavoritesInsert, Model.Requests.Favorites.FavoritesInsert>
    {
        public FavoritesService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Favorites> Get(FavoritesSearchRequest search)
        {
            var query = _context.Favorites.AsQueryable();
            if(search.UserId > 0) {
                query = query.Where(w => w.UserId == search.UserId);
            }

            if(search.VehicleId > 0)
            {
                query = query.Where(w => w.VehicleId == search.VehicleId);
            }

            return _mapper.Map <List<Model.Favorites>>(query.ToList());
        }
    }
}
