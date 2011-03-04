using System.Linq.Expressions;

namespace nothinbutdotnetstore.utility
{
    public class DefaultPropertyNameExpressionMapper : PropertyNameExpressionMapper
    {
        public string map_from<Item>(Expression<PropertyAccessor<Item, object>> property_accessor)
        {
            return ((MemberExpression)property_accessor.Body).Member.Name;
        }
    }
}