using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestData.Entities;
using RequestDataAccess.Interfaces;

namespace RequestWebApi.Endpoints.RequestEndpoint;

[ApiController]
[Authorize]
public class Create : ControllerBase
{
    private IRequestEndpointService _service;
    private IMapper _mapper;

    public Create(IRequestEndpointService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("api/request")] 
    public ActionResult HandleAsync([FromBody] CreateRequestBody body) {
        Request request = _mapper.Map<Request>(body);
        request.RequestStatusId = -1;
        request.FromUserId = -1;
        request.CreatedAt = DateTime.UtcNow;
        _service.CreateAsync(request);
        return Ok();
    }
    
    
}
