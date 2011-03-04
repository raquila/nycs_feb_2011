using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVisitor : UrlFormattingVisitor
    {

        public string url { get; set; }
        

        public void visit(KeyValuePair<string, object> item)
        {
            url += string.Format("{0}={1}", item.Key, item.Value);
        }

        public string get_result()
        {
            return url;
        }
    }
}