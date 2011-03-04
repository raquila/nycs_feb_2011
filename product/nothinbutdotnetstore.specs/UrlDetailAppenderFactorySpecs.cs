 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.utility;
 using nothinbutdotnetstore.web.core;

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
            private class Detail
            {
            }

            private Establish c = () =>
                                      {
                                          the_dependency<PropertyNameExpressionMapper>();
                                          the_detail = new Detail();
                                          token_store = an<TokenStore>();
                                      };

            private Because b = () =>
                                result = sut.create_detail_appender_for(the_detail, token_store);

            private It should_create_detailed_appender_with_all_information = () => result.ShouldNotBeNull();
            private static UrlDetailAppender<Detail> result;
            private static Detail the_detail;
            private static TokenStore token_store;
        }
    }
}
