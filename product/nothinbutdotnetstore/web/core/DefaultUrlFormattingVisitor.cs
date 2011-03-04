using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVisitor : UrlFormattingVisitor
    {

        private string url { get; set; }
        

        public void visit(KeyValuePair<string, object> item)
        {
            if (!string.IsNullOrEmpty(url))
                url += "&";

            url += string.Format("{0}={1}", item.Key, item.Value);
        }

        public string get_result()
        {
            return url;
        }
    }
}