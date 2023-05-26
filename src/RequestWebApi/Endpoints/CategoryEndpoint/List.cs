using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestDataAccess.Interfaces;
using RequestDataAccess.Models;

namespace RequestWebApi.Endpoints.CategoryEndpoint;

[ApiController]
[Authorize]
public class List : ControllerBase
{
    private ICategoryEndpointService _service;
    private IMapper _mapper;

    public List(ICategoryEndpointService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/category", Name = "[controller]")]
    public ListResultEnvelope<CategoryDto> GetAll() {
        
        var list =  _service.ListAsync();
        var count = list.Count;
        List<CategoryDto>? dto = _mapper.Map<List<CategoryDto>>(list);
        return new ListResultEnvelope<CategoryDto>() {Data = dto, Count = count};
    }

}
