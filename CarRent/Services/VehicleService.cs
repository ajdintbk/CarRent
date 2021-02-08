using AutoMapper;
using CarRent.Model.Requests.Vehicle;
using CarRent.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class VehicleService : BaseCRUDService<Model.Vehicle, Model.Requests.Vehicle.VehicleSearchRequest, Database.Vehicle, Model.Requests.Vehicle.VehicleInsert, Model.Requests.Vehicle.VehicleInsert>
    {
        public VehicleService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }
        
        public override Model.Vehicle Insert(VehicleInsert request)
        {
            return base.Insert(request);
        }
        public override Model.Vehicle Update(int id, VehicleInsert request)
        {
            var vehicle = _context.Vehicles.Find(id);
            if(vehicle != null)
            {
                if(vehicle.Image.Length > 0 && request.Image == null)
                {
                    request.Image = vehicle.Image;
                }
            }
            return base.Update(id, request);
        }
        public override Model.Vehicle GetByID(int id)
        {
            var vehicle = _context.Vehicles.Include(e => e.VehicleType)
                .Include(e => e.Brand).Include(e => e.VehicleModel).FirstOrDefault(f => f.Id == id);

            return _mapper.Map<Model.Vehicle>(vehicle);
        }

        public override List<Model.Vehicle> Get(VehicleSearchRequest search)
        {
            var query = _context.Vehicles.Include(e => e.VehicleType).Include(e=>e.Fuel)
                    .Include(e => e.Brand).Include(e => e.VehicleModel).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(w => w.Name.Contains(search.Name));
            }

            if(search.BrandId > 0)
            {
                query = query.Where(w => w.BrandId == search.BrandId);

            }

            if(search.IsActive == false)
            {
               query= query.Where(w => w.IsActive == false);
            }
            if(search.IsActive == true)
            {
                query = query.Where(w => w.IsActive == true);
            }
            


            return _mapper.Map<List<Model.Vehicle>>(query.ToList());

        }

        

    }
}
