using System;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlDecorator
    {
        UrlDecorator include_payload<PayloadItem>(PayloadItem item, UrlDetailConfiguration<PayloadItem> config);
    }
}