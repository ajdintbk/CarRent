using AutoMapper;
using CarRent.Model.Requests.Rent;
using CarRent.WebApi.Database;
using CarRent.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class RentService : IRentService
    {
        readonly CarRentContext _context;
        readonly IMapper _mapper;
        public RentService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Rent> CheckAvailability(RentSearchRequest search)
        {
            var rents = _context.Rents.Where(w => w.VehicleId == search.VehicleId).Where(w => w.StartDate <= search.StartDate && w.EndDate >= search.StartDate || w.EndDate <= search.EndDate && w.EndDate >= search.EndDate).ToList();
            if (rents.Count > 0)
            {
                return _mapper.Map<List<Model.Rent>>(rents);
            }
            else
            {
                return null;
            }
        }

        public Model.Rent Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Rent> Get(RentSearchRequest search)
        {

            var query = _context.Rents.Include(i => i.User).Include(i => i.Vehicle).AsQueryable();

            if (search.StartDate != null && search.EndDate != null)
            {
                var sd = search.StartDate.Value.Date;
                var ed = search.EndDate.Value.Date;

                query = query.Where(e => e.StartDate.Date >= sd && e.EndDate.Date <= ed);
            }

            if (!string.IsNullOrWhiteSpace(search.UserName))
            {
                query = query.Where(w => w.User.FirstName == search.UserName);
            }

            if (!string.IsNullOrWhiteSpace(search.UserLastName))
            {
                query = query.Where(w => w.User.LastName == search.UserLastName);
            }

            if (search.UserId != 0)
            {
                query = query.Where(w => w.UserId == search.UserId);
            }

            if (!string.IsNullOrWhiteSpace(search.VehicleName))
            {
                query = query.Where(w => w.Vehicle.Name == search.VehicleName);
            }

            if (search.VehicleId != 0)
            {
                query = query.Where(w => w.Vehicle.Id == search.VehicleId);
            }

            if (search.RentId > 0)
            {
                query = query.Where(w => w.Id == search.RentId);
            }
            query = query.OrderBy(x => x.StartDate);



            return _mapper.Map<List<Model.Rent>>(query.ToList());
        }


        public Model.Rent GetById(int id)
        {
            var entity = _context.Rents.Include(i => i.User).Include(i => i.Vehicle).FirstOrDefault(w => w.Id == id);
            if (entity != null)
            {
                return _mapper.Map<Model.Rent>(entity);
            }
            else
            {
                return null;
            }
        }

        public Model.Rent Insert(RentInsert request)
        {

            var rents = _context.Rents.Where(w => w.VehicleId == request.VehicleId).Where(w => w.StartDate <= request.StartDate && w.EndDate >= request.StartDate || w.EndDate <= request.EndDate && w.EndDate >= request.EndDate).ToList();

            if (rents.Count == 0)
            {
                var newRent = _mapper.Map<Database.Rent>(request);
                _context.Rents.Add(newRent);
                _context.SaveChanges();
                return _mapper.Map<Model.Rent>(newRent);
            }
            else
            {
                return null;
            }
        }



        public Model.Rent Update(int id, RentInsert request)
        {
            var entity = _context.Rents.Find(id);

            _context.Rents.Attach(entity);
            _context.Rents.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Rent>(entity);
        }

        public List<Model.Rent> FutureRents(int id)
        {
            var query = _context.Rents.Include(i=>i.Vehicle).Include(i=>i.User).Where(w => w.UserId == id && w.StartDate.Date > DateTime.Now.Date).ToList();
            return _mapper.Map<List<Model.Rent>>(query);
        }

        public Model.Rent Cancel(int id)
        {
            var entity = _context.Rents.Find(id);
            if(entity != null)
            {
                entity.IsCanceled = true;
            }

            _context.Update(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rent>(entity);
        }
    }
}
