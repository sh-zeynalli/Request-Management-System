using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RequestWebApi.Helpers;

public static class Filtering
{
    public static IEnumerable<T> ApplyFilters<T>(this IEnumerable<T> querable, Dictionary<string, FilterBody> filters)
    {
        if (filters.Count != 0)
        {
            foreach (var filter in filters)
            {
                var propertyName = PropertyHelper.GetPropertyName(filter.Key);

                Type type = typeof(T); //Request

                ParameterExpression param = Expression.Parameter(type, "request");

                var prop = Expression.Property(param, propertyName);

                Type propType = prop.Type;

                object filterValue = filter.Value.FilterValue;

                filterValue = Convert.ChangeType(filterValue, propType);

                ConstantExpression? filterValueCons = Expression.Constant(filterValue, propType);

                Type expressionType = typeof(bool);

                var propAccess = Expression.Equal(left: prop, filterValueCons);

                Type genericType = typeof(Func<,>).MakeGenericType(type, expressionType);
                //x => x.Id == 3
                LambdaExpression expression = Expression.Lambda(genericType, propAccess, param);

                var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "Where" && m.GetParameters().Length == 2);

                var genericMethod = method.MakeGenericMethod(type);

                querable = (IEnumerable<T>)genericMethod.Invoke(querable, new object[] { querable, expression.Compile() });

            }

        }
        return querable;
    }
}
