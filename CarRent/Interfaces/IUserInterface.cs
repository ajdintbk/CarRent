using CarRent.Model.Requests;
using CarRent.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Interfaces
{
    public interface IUserInterface
    {
        public List<Model.User> Get(Model.Requests.User.UserSearchRequest request);
        public Model.User GetById(int id);
        public Model.User AddUser(AddUserRequest req);
        Model.User Update(int id, AddUserRequest request);
        Model.User Authenticate(Model.Requests.User.UserLoginRequest request);
    }
}
