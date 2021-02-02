using AutoMapper;
using CarRent.Model.Requests;
using CarRent.Model.Requests.User;
using CarRent.WebApi.Database;
using CarRent.WebApi.Interfaces;
using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class UserService : IUserInterface
    {
        readonly CarRentContext _context;
        readonly IMapper _mapper;
        public UserService(CarRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.User AddUser(AddUserRequest req)
        {
            var validate = _context.Users.FirstOrDefault(w => w.Username == req.Username);
            if(validate != null)
            {
                return null;
            }
            var user = _mapper.Map<Database.User>(req);
            user.PasswordSalt = HashGenerator.GenerateSalt();
            user.PasswordHash = HashGenerator.GenerateHash(user.PasswordSalt, req.Password);
            user.RoleId = req.RoleId;
            user.CityId = req.CityId;
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<Model.User>(user);
        }

        public Model.User Authenticate(UserLoginRequest request)
        {
            var user = _context.Users.Include(i => i.Role).FirstOrDefault(x => x.Username == request.Username);

            if (user != null)
            {
                var newHash = HashGenerator.GenerateHash(user.PasswordSalt, request.Password);

                if (user.PasswordHash == newHash)
                {
                    return _mapper.Map<Model.User>(user);
                }
            }
            return null;
        }

        public List<Model.User> Get(UserSearchRequest request)
        {
            var query = _context.Users.Include(x=>x.Role).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                query = query.Where(x => x.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrWhiteSpace(request.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                query = query.Where(x => x.Username == request.Username);
            }
            
            if(request.RoleId.HasValue == true)
            {
                query = query.Where(x => x.RoleId == request.RoleId);
            }

            if(request.UserId > 0)
            {
                query = query.Where(x => x.Id == request.UserId);
            }

            return _mapper.Map<List<Model.User>>(query.ToList());
        }

        public Model.User GetById(int id)
        {
            var user = _context.Users.Find(id);
            return _mapper.Map<Model.User>(user);
        }

        public Model.User Update(int id, AddUserRequest request)
        {
            var entity = _context.Users.Find(id);

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }
    }
}
