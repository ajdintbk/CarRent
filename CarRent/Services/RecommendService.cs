using AutoMapper;
using CarRent.Model;
using CarRent.WebApi.Database;
using CarRent.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class RecommendService : IRecommendService
    {
        protected readonly CarRentContext _context;
        protected readonly IMapper _mapper;

        public RecommendService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Dictionary<int, List<Database.Review>> vehicles = new Dictionary<int, List<Database.Review>>();

        public List<Model.Vehicle> RecommendVehicle(int vehicleId)
        {
            var tmp = LoadSimilar(vehicleId);
            return _mapper.Map<List<Model.Vehicle>>(tmp);
        }

        private List<Database.Vehicle> LoadSimilar(int vehicleId)
        {
            LoadDifVehicles(vehicleId);
            List<Database.Review> ratingsOfThis =_context.Reviews.Where(e => e.VehicleId == vehicleId).OrderBy(e => e.UserId).ToList();

            List<Database.Review> ratings1 = new List<Database.Review>();
            List<Database.Review> ratings2 = new List<Database.Review>();
            List<Database.Vehicle> recommendedVehicles = new List<Database.Vehicle>();

            foreach (var item in vehicles)
            {
                foreach (Database.Review rating in ratingsOfThis)
                {
                    if (item.Value.Where(x => x.UserId == rating.UserId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(item.Value.Where(x => x.UserId == rating.UserId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recommendedVehicles.Add(_context.Vehicles.Where(x => x.Id == item.Key)
                        .Include(x => x.VehicleModel)
                        .Include(x=>x.Fuel).Include(x=>x.Brand).Include(x=>x.VehicleType)
                        .FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedVehicles;
        }

        private double GetSimilarity(List<Database.Review> ratings1, List<Database.Review> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].NumberOfStars * ratings2[i].NumberOfStars;
                y1 += ratings1[i].NumberOfStars * ratings1[i].NumberOfStars;
                y2 += ratings2[i].NumberOfStars * ratings2[i].NumberOfStars;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadDifVehicles(int vehicleId)
        {
            List<Database.Vehicle> allVehicles = _context.Vehicles.Where(e => e.Id != vehicleId).ToList();
            List<Database.Review> ratings = new List<Database.Review>();
            foreach (var item in allVehicles)
            {
                ratings =_context.Reviews.Where(e => e.VehicleId == item.Id).OrderBy(e => e.UserId).ToList();
                if (ratings.Count > 0)
                    vehicles.Add(item.Id, ratings);
            }
        }
    }
}

