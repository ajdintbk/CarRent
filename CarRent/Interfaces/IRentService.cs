using CarRent.Model.Requests.Rent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Interfaces
{
    public interface IRentService
    {
        Model.Rent Insert(RentInsert request);
        Model.Rent Update(int id, RentInsert reqest);
        List<Model.Rent> Get(RentSearchRequest search);
        List<Model.Rent> CheckAvailability(RentSearchRequest search);
        Model.Rent GetById(int id);
        Model.Rent Delete(int id);
    }
}
