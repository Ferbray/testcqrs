using AutoMapper;
using testcqrs.ModuleName.Entities;
using testcqrs.ModuleName.Requests;
using testcqrs.ModuleName.Responses;

namespace testcqrs.ModuleName.Contracts.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserResponse>();
    }
}