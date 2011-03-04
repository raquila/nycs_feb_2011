using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs
{
    public class UrlDetailAppenderFactorySpecs
    {
        public abstract class concern : Observes<UrlDetailAppenderFactory,
                                            DefaultUrlDetailAppenderFactory>
        {
        }

        [Subject(typeof(DefaultUrlDetailAppenderFactory))]
        public class when_creating_the_detail_appender : concern
        {
            class Detail
            {
            }

            Establish c = () =>
            {
                mapper = the_dependency<PropertyNameExpressionMapper>();
                the_detail = new Detail();
                token_store = an<TokenStore>();
            };

            Because b = () =>
                result = sut.create_detail_appender_for(the_detail, token_store);

            It should_create_detailed_appender_with_all_information = () =>
            {
                var detail_appender = result.ShouldBeAn<DefaultUrlDetailAppender<Detail>>();
                detail_appender.tokens.ShouldEqual(token_store);
                detail_appender.property_name_expression_mapper.ShouldEqual(mapper);
                detail_appender.item.ShouldEqual(the_detail);
            };

            static UrlDetailAppender<Detail> result;
            static Detail the_detail;
            static TokenStore token_store;
            static PropertyNameExpressionMapper mapper;
        }
    }
}