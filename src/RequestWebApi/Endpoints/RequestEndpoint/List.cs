using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RequestData;
using RequestDataAccess.Interfaces;
using RequestData.Entities;
using RequestDataAccess.Models;
using RequestWebApi.Common;
using RequestWebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RequestWebApi.Endpoints.RequestEndpoint;

[ApiController]
//[Authorize]
public class List: ControllerBase
{
    private IRequestEndpointService _service;
    private IMapper _mapper;

    public List(IRequestEndpointService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("api/request/list")]
    public async Task<ListResultEnvelope<RequestDto>> Get([FromBody] RequestFilterBody body) {

        body.Limit = body.Limit ?? Constants.FETCH_LIMIT;
        body.Offset = body.Offset ?? Constants.FETCH_OFFSET;

        var queryable = await _service.GetListAsync();

        queryable = queryable.ApplyFilters(body.Filters);
        var entities =  queryable.OrderByProperty(body.SortField, body.SortOrder)
                                        .Skip(body.Offset.Value)
                                        .Take(body.Limit.Value);
                                                                                
        List<RequestDto> dtos = _mapper.Map<List<RequestDto>>(entities);

        return  new ListResultEnvelope<RequestDto>() {Data = dtos, Count = queryable.Count()};

    }
}
