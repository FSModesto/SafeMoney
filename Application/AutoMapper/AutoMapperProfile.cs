using Application.ViewModel.Request;
using Application.ViewModel.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();

            CreateMap<LoginRequest, User>();
            CreateMap<User, LoginResponse>();

            CreateMap<GetUserByIdRequest, User>();
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
