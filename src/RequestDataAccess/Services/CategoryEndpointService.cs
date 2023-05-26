using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RequestData;
using RequestDataAccess.Interfaces;
using RequestDataAccess.Models;

namespace RequestDataAccess.Services;

public class CategoryEndpointService : ICategoryEndpointService

{
    private DataContext _context;
    private readonly IMapper _mapper;
    public CategoryEndpointService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public List<RequestData.Entities.Category> ListAsync()
    {
        return _context.Categories.ToList();
    }
}
