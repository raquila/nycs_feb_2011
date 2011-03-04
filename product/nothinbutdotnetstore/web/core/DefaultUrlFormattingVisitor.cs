using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVisitor : UrlFormattingVisitor
    {
        StringBuilder builder;

        public DefaultUrlFormattingVisitor(StringBuilder builder)
        {
            this.builder = builder;
        }

        public void visit(KeyValuePair<string, object> item)
        {
            builder.AppendFormat("{0}.nyc", item.Value.ToString());
        }

        public string get_result()
        {
            return builder.ToString();
        }
    }
}