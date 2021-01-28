using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseCRUDController<Model.Message, Model.Requests.Message.MessageSearchRequest, Model.Requests.Message.MessageInsert, Model.Requests.Message.MessageInsert>
    {
        public MessageController(ICRUDService<Model.Message, Model.Requests.Message.MessageSearchRequest, Model.Requests.Message.MessageInsert, Model.Requests.Message.MessageInsert> service) : base(service)
        {
        }
    }
}
