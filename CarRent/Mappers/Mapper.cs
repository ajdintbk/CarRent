using AutoMapper;
using CarRent.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.User, AddUserRequest>().ReverseMap();
            CreateMap<Database.User, Model.Requests.User.UserSearchRequest>().ReverseMap();

            CreateMap<Database.Vehicle, Model.Requests.Vehicle.VehicleInsert>().ReverseMap();
            CreateMap<Model.Requests.AddVehicleRequest, Database.Vehicle>().ReverseMap();
            CreateMap<Model.Vehicle, Database.Vehicle>().ReverseMap();
            CreateMap<Database.Vehicle, Model.ViewModel.VehicleListVM>().ReverseMap();

            CreateMap<Model.VehicleModel, Database.VehicleModel>().ReverseMap();
            CreateMap<Database.VehicleModel, Model.Requests.VehicleModel.VehicleModelSearchRequest>().ReverseMap();
            CreateMap<Database.VehicleModel, Model.Requests.VehicleModel.VehicleModelInsert>().ReverseMap();

            CreateMap<Model.Fuel, Database.Fuel>().ReverseMap();
            CreateMap<Model.VehicleType, Database.VehicleType>().ReverseMap();
            CreateMap<Model.Brand, Database.Brand>().ReverseMap();

            CreateMap<Database.City, Model.City>().ReverseMap();
            CreateMap<Database.City, Model.Requests.City.CitySearchRequest>().ReverseMap();
            CreateMap<Database.City, Model.Requests.City.CityRequest>().ReverseMap();

            CreateMap<Database.Message, Model.Message>().ReverseMap();
            CreateMap<Database.Message, Model.Requests.Message.MessageInsert>().ReverseMap();

            CreateMap<Database.Rent, Model.Rent>().ReverseMap();
            CreateMap<Database.Rent, Model.Requests.Rent.RentInsert>().ReverseMap();
            CreateMap<Database.Rent, Model.Rent>().ReverseMap();

            CreateMap<Database.Review, Model.Review>().ReverseMap();
            CreateMap<Database.Review, Model.Requests.Review.ReviewInsert>().ReverseMap();

            CreateMap<Database.Role, Model.Role>().ReverseMap();
            CreateMap<Database.Role, Model.Requests.Role.RoleSearchRequest>().ReverseMap();

            CreateMap<Database.Favorites, Model.Favorites>().ReverseMap();
            CreateMap<Database.Favorites, Model.Requests.Favorites.FavoritesInsert>().ReverseMap();
            CreateMap<Database.Favorites, Model.Requests.Role.RoleSearchRequest>().ReverseMap();

        }
    }
}
