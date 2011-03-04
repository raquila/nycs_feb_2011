using System;
using System.Linq.Expressions;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.utility
{
    public class DefaultPropertyNameExpressionMapper:PropertyNameExpressionMapper
    {
        public string map_from<Item>(Expression<PropertyAccessor<Item, object>> property_accessor)
        {
            return property_accessor.Body.downcast_to<MemberExpression>()
               .Member.Name;
        }
    }
}