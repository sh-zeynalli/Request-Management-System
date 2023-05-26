using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequestData.Entities;

namespace RequestDataAccess.Interfaces;

public interface IUserEndpointService
{
    public User GetByUsername(string username);
}
