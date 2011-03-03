﻿using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core
{
    public static class Url
    {
        public static UrlFormatter<BehaviourToRun> to_run<BehaviourToRun>()
            where BehaviourToRun : ApplicationBehaviour
        {
            return new UrlFormatter<BehaviourToRun>();
                
                //get_url_name<BehaviourToRun>()
        }

       /* static string get_url_name<BehaviourToRun>()
        {
            return string.Format("{0}.nyc", typeof(BehaviourToRun).Name);
        }*/

        public static RequestMatch to_match_request_for<BehaviourToMatch>() where BehaviourToMatch
                                                                                : ApplicationBehaviour
        {
            return new RequestContainsCommand<BehaviourToMatch>().matches;
        }

        public static string to_run_iif<Left, Right>(bool condition)
        {
//            return (condition ? get_url_name<Left>() : get_url_name<Right>());
            return (condition ? new UrlFormatter<Left>().format() : new UrlFormatter<Right>().format());

        }

    }
}