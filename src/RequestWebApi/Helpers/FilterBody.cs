using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestWebApi.Helpers;

public class FilterBody
{
    public string FilterValue { get; set; }
    public string FilterType  { get; set; }
    public string Comparator { get; set; }
    public bool CaseSensitive { get; set; }
}
