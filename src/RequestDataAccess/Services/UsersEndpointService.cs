using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RequestData;
using RequestData.Entities;
using RequestDataAccess.Interfaces;

namespace RequestDataAccess.Services;

public class UsersEndpointService : Interfaces.IUserEndpointService
{

    private DataContext _context;
    private readonly IMapper _mapper;

    public UsersEndpointService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public User GetByUsername(string username) {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }
}
