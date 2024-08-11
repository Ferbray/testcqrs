using AutoMapper;
using testcqrs.Domain.Entities;
using testcqrs.Domain.Requests;
using testcqrs.Domain.Responses;

namespace testcqrs.Domain.Mapping;
public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserResponse>();
    }
}