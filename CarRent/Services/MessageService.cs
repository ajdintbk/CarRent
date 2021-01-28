using AutoMapper;
using CarRent.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Services
{
    public class MessageService : BaseCRUDService<Model.Message, Model.Requests.Message.MessageSearchRequest, Database.Message, Model.Requests.Message.MessageInsert, Model.Requests.Message.MessageInsert>
    {
        public MessageService(CarRentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.Message GetByID(int id)
        {
            var query = _context.Messages.Include(i => i.User).FirstOrDefault(w => w.Id == id);

            return _mapper.Map<Model.Message>(query);
        }
    }
}
