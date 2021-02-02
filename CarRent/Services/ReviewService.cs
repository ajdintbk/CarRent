using AutoMapper;
using CarRent.Model.Requests.Review;
using CarRent.WebApi.Database;
using CarRent.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class ReviewService : BaseCRUDService<Model.Review, Model.Requests.Review.ReviewSearchRequest, Database.Review, Model.Requests.Review.ReviewInsert, Model.Requests.Review.ReviewInsert>
    {
        public ReviewService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Review> Get(ReviewSearchRequest search)
        {
            var query = _context.Reviews.Include(i => i.User).Include(i => i.Vehicle).AsQueryable();

            if(search.Id != 0)
            {
                query = query.Where(w => w.Id == search.Id);
            }

            if (!string.IsNullOrWhiteSpace(search.Comment))
            {
                query = query.Where(w => w.Comment == search.Comment);
            }

            if(search.NumberOfStars != 0)
            {
                query = query.Where(w => w.NumberOfStars == search.NumberOfStars);
            }

            if(search.DatePosted != null)
            {
                query = query.Where(w => w.DatePosted == search.DatePosted);
            }

            if(search.UserId != 0)
            {
                query = query.Where(w => w.UserId == search.UserId);
            }

            if (!string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(w => w.User.FirstName == search.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(w => w.User.LastName == search.LastName);
            }

            if(search.VehicleId != 0)
            {
                query = query.Where(w => w.VehicleId == search.VehicleId);
            }

            if (!string.IsNullOrWhiteSpace(search.VehicleName))
            {
                query = query.Where(w => w.Vehicle.Name == search.VehicleName);
            }

            query.OrderBy(o => o.DatePosted);

            return _mapper.Map<List<Model.Review>>(query);
        }


        public override Model.Review GetByID(int id)
        {
            var query = _context.Reviews.Include(i => i.User).Include(i => i.Vehicle).FirstOrDefault(w=>w.Id == id);
            return _mapper.Map<Model.Review>(query);
        }

       
    }
}
