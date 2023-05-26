using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestWebApi.Endpoints.RequestEndpoint;

public class CreateRequestBody
{
    public string Header { get; set; } = null!;
    public string Body { get; set; } = null!;
    public int CategoryId { get; set; }
}
