using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlBuilder : UrlBuilder, UrlDecorator
    {
        public object payload;
        public const string command_key = "command_to_run";
        TokenStore tokens;
        UrlDetailAppenderFactory url_detail_appender_factory;
        UrlFormattingVisitor url_formatting_visitor;

        public DefaultUrlBuilder(TokenStore tokens,
                                 UrlDetailAppenderFactory url_detail_appender_factory,
                                 UrlFormattingVisitor url_formatting_visitor)
        {
            this.tokens = tokens;
            this.url_formatting_visitor = url_formatting_visitor;
            this.url_detail_appender_factory = url_detail_appender_factory;
        }

        public UrlDecorator target<BehaviourToTarget>() where BehaviourToTarget : ApplicationBehaviour
        {
            tokens.register_token_pair(command_key, typeof(BehaviourToTarget).Name);

            return create_new_instance();
        }

        UrlDecorator create_new_instance()
        {
            return new DefaultUrlBuilder(tokens, url_detail_appender_factory, url_formatting_visitor);
        }

        public UrlDecorator include_payload<PayloadItem>(PayloadItem item,
                                                         UrlDetailConfiguration<PayloadItem> appender_configuration)
        {
            appender_configuration(url_detail_appender_factory.create_detail_appender_for(item, tokens));
            return create_new_instance();
        }

        public override string ToString()
        {
            return tokens.get_the_result_of_visiting_all_items_with(url_formatting_visitor);
        }
    }
}