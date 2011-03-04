using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVisitor : UrlFormattingVisitor
    {
        private readonly StringBuilder _string_builder;

        
        public DefaultUrlFormattingVisitor(StringBuilder string_builder)
        {
            _string_builder = string_builder;
        }

        public void visit(KeyValuePair<string, object> item)
        {
            if (!string.IsNullOrEmpty(_string_builder.ToString()))
                _string_builder.Append("&");

            _string_builder.Append(item.Key);
            _string_builder.Append("=");
            _string_builder.Append(item.Value);
        }

        public string get_result()
        {
            return _string_builder.ToString();
        }
    }
}