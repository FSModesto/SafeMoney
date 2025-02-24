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
        }
    }
}
