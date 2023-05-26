using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using RequestWebApi.Common;

namespace RequestWebApi.Helpers;

public static class Sorting
{
    public static IEnumerable<T> OrderByProperty<T>(this IEnumerable<T> queryable, string SortField, string SortOrder)
    {

        SortField = SortField ?? Constants.DEFAULT_SORTFIELD;
        SortOrder = SortOrder ?? Constants.DEFAULT_SORTORDER;

        string propertyName = PropertyHelper.GetPropertyName(SortField);

        Type type = typeof(T); //type - Request entity
        ParameterExpression param = Expression.Parameter(type, "request"); //creates ParameterExpression with the type of "type"

        PropertyInfo info = type.GetProperty(propertyName); //returns the property of name prop -- in this case ex: Request.Body
        Expression propAccess = Expression.Property(param, info); //expression to access to prop, in this case it will be used to access request.body
        Type typeProp = info.PropertyType; //type of property , int this case type of Request.Body - string

        Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), typeProp);

        var expr = Expression.Lambda(delegateType, propAccess, param);

        var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
        var genericMethod = method.MakeGenericMethod(type, typeProp);

        return (IEnumerable<T>)genericMethod.Invoke(queryable, new object[] { queryable, expr.Compile() });

    }
}
