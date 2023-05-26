using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestWebApi.Helpers;

public static class PropertyHelper
{
    public static string GetPropertyName(string fieldName) {
        
        return char.ToUpperInvariant(fieldName[0]) + fieldName.Substring(1);
    }
}
