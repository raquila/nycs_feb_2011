using System;
using System.Linq.Expressions;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlDetailAppender<PayloadItem>
    {
        UrlDetailAppender<PayloadItem> include(Expression<PropertyAccessor<PayloadItem, object>> property_accessor);
    }
}