using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequestWebApi.Helpers;

namespace RequestWebApi.Endpoints.RequestEndpoint;

public class RequestFilterBody
{
    public int? Limit { get; set; }
    public int?  Offset { get; set; }
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public Dictionary<string, FilterBody> Filters { get; set; }
}
