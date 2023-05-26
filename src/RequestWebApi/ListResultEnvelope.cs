using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequestDataAccess.Models;

namespace RequestWebApi.Endpoints;

public class ListResultEnvelope<T>
{
    public List<T>? Data { get; set; }
    public int Count { get; set; }
}

