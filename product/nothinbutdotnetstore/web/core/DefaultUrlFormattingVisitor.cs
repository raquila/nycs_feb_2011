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
            if (builder.ToString()==string.Empty)
                builder.AppendFormat("{0}.nyc", item.Value.ToString() );
            else
            {
                if (!builder.ToString().Contains("?"))
                    builder.Append("?");

                builder.AppendFormat("{0}={1}", item.Key, item.Value);
            }
        }

        public string get_result()
        {
            return builder.ToString();
        }
    }
}