using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Interfaces
{
    public interface IRecommendService
    {
        List<Model.Vehicle> RecommendVehicle(int vehicleId);
    }
}
