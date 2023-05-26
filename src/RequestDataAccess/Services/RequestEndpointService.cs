using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestData;
using RequestData.Entities;
using RequestDataAccess.Interfaces;

namespace RequestDataAccess.Services;

public class RequestEndpointService : IRequestEndpointService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public RequestEndpointService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Request>> GetListAsync()
    {
        return _context.Requests.Include(u=>u.FromUser).Include(c => c.Category); 
    }

    public void CreateAsync(Request request)
    {
        _context.Requests.Add(request);
        _context.SaveChanges();
    }
}
