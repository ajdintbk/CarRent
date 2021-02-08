using CarRent.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi
{
    public class SetupService
    {
        public static void Init(CarRentContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
