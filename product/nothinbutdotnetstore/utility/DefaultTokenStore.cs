using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public class DefaultTokenStore : TokenStore
    {
        IList<KeyValuePair<string, object>> all_tokens;

        public DefaultTokenStore(IList<KeyValuePair<string, object>> all_tokens)
        {
            this.all_tokens = all_tokens;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return all_tokens.GetEnumerator();
        }

        public void register_token_pair(string key, object value)
        {
            all_tokens.Add(new KeyValuePair<string, object>(key, value));
        }
    }
}