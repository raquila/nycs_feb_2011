using System;

namespace nothinbutdotnetstore.web.core
{
    public class UrlFormatter<T>
    {
        static string get_url_name<T>()
        {
            return string.Format("{0}.nyc", typeof(T).Name);
        }

        public string format()
        {
            return get_url_name<T>();
        }

        public UrlFormatter<T> include_in_payload<K>(K item)
        {
            throw new NotImplementedException();
        }

       /* public UrlFormatter<T> the_detail(Func<T, K> func)
        {
            throw new NotImplementedException();
        }*/
    }
}