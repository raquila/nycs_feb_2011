using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public interface TokenStore: IEnumerable<KeyValuePair<string,object>>
    {
        void register_token_pair(string key,object value);
    }
}