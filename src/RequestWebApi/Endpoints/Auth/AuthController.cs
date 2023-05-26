using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestData;
using RequestDataAccess.Interfaces;
using RequestWebApi.Endpoints.Security;

namespace RequestWebApi.Endpoints.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private ILogger<AuthController> logger;
    private IUserEndpointService service;
    private IMapper mapper;
    private IApiJwtTokenGenerator tokenGenerator;

    public AuthController(IUserEndpointService _service, IApiJwtTokenGenerator _tokenGenerator, IMapper _mapper)
    {
        service = _service;
        tokenGenerator = _tokenGenerator;
        mapper = _mapper;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<LoginResponse> Signin([FromBody] LoginRequest request)
    {
        var handler = new Login.Handler(service, mapper, tokenGenerator);
        var response = await handler.Handle(request);
        return response;
    }



}
