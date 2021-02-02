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
    public class FavoritesController : BaseCRUDController<Model.Favorites, Model.Requests.Favorites.FavoritesSearchRequest, Model.Requests.Favorites.FavoritesInsert, Model.Requests.Favorites.FavoritesInsert>
    {
        ICRUDService<Model.Favorites, Model.Requests.Favorites.FavoritesSearchRequest, Model.Requests.Favorites.FavoritesInsert, Model.Requests.Favorites.FavoritesInsert> _service;
        public FavoritesController(ICRUDService<Model.Favorites, Model.Requests.Favorites.FavoritesSearchRequest, Model.Requests.Favorites.FavoritesInsert, Model.Requests.Favorites.FavoritesInsert> service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }


 
}
