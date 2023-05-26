using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RequestData;
using RequestData.Entities;
using RequestWebApi.Endpoints.Security;
using RequestDataAccess.Interfaces;

namespace RequestWebApi.Endpoints.Auth;

public class Login
{
    public class Handler
    {
        private IUserEndpointService service;
        private IMapper mapper;
        private IApiJwtTokenGenerator tokenGenerator;

        public Handler(IUserEndpointService _service, IMapper _mapper, IApiJwtTokenGenerator _tokenGenerator)
        {
            service = _service;
            mapper = _mapper;
            tokenGenerator = _tokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginRequest request)
        {

            var user = service.GetByUsername(request.Username);
            if (user is null)
            {
                throw new Exception("Username or password is incorrect");
            }

            var isAuthenticated = false;

            try
            {
                isAuthenticated = AuthenticateUser(request);
            }
            catch (Exception e)
            {

            }
            if (!isAuthenticated)
            {
                throw new Exception("Username or password is incorrect");
            }

            var loginDto = mapper.Map<User, LoginResponse>(user);
            loginDto.Token = await tokenGenerator.GenerateToken(loginDto.Id.ToString(), loginDto.Username);
            
            return loginDto;

        }

        private bool AuthenticateUser(LoginRequest request)
        {
            return true;
        }
    }
}
