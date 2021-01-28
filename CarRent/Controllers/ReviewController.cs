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
    public class ReviewController : BaseCRUDController<Model.Review, Model.Requests.Review.ReviewSearchRequest, Model.Requests.Review.ReviewInsert, Model.Requests.Review.ReviewInsert>
    {
        public ReviewController(ICRUDService<Model.Review, Model.Requests.Review.ReviewSearchRequest, Model.Requests.Review.ReviewInsert, Model.Requests.Review.ReviewInsert> service) : base(service)
        {
        }
    }
}
