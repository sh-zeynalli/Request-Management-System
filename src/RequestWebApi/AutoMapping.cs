using AutoMapper;
using RequestData.Entities;
using RequestDataAccess.Models;
using RequestWebApi.Endpoints.Auth;
using RequestWebApi.Endpoints.RequestEndpoint;

namespace RequestWebApi;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<RequestData.Entities.Category, CategoryDto>();

        CreateMap<RequestData.Entities.Request, RequestDto>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(c => c.Category.CategoryName))
                .ForMember(d => d.Username, opt => opt.MapFrom(u => u.FromUser.Username));

        CreateMap<CreateRequestBody, Request>();

        CreateMap<RequestData.Entities.User, LoginResponse>();
    }

}
