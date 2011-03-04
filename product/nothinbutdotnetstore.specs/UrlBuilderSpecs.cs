using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class UrlBuilderSpecs
    {
        public abstract class concern<ContractToObserve, Class> : Observes<ContractToObserve,
                                                                      Class> where Class : ContractToObserve
        {
            Establish c = () => { token_store = the_dependency<TokenStore>(); };

            protected static TokenStore token_store;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_targeting_a_behaviour_to_run : concern<UrlBuilder, DefaultUrlBuilder>
        {
            Because b = () =>
                result = sut.target<OurBehaviour>();

            It should_store_the_behaviour_to_run_with_the_correct_details = () =>
            {
                token_store.received(x => x.register_token_pair(DefaultUrlBuilder.command_key,
                                                                typeof(OurBehaviour).Name));
            };

            It should_return_a_url_decorator_to_continue_the_url_building_process =
                () => { result.ShouldBeAn<UrlDecorator>().Equals(sut).ShouldBeFalse(); };

            static UrlDecorator result;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_including_a_payload : concern<UrlDecorator, DefaultUrlBuilder>
        {
            Establish c = () =>
            {
                our_item = new TheItem();
                detail_appender = an<UrlDetailAppender<TheItem>>();
                name_pointer = x => x.name;
                url_detail_appender_factory = the_dependency<UrlDetailAppenderFactory>();

                url_detail_appender_factory.Stub(x => x.create_detail_appender_for(our_item, token_store))
                    .Return(detail_appender);

                appender_configuration = appender =>
                {
                    appender.include(name_pointer);
                };
            };

            Because b = () =>
                result = sut.include_payload(our_item,appender_configuration);

            It should_run_the_appender_configuration_against_the_appender_created_by_the_factory = () =>
                detail_appender.received(x => x.include(name_pointer));

            It should_return_a_url_decorator_to_continue_url_building = () =>
                result.ShouldBeAn<UrlDecorator>().ShouldNotEqual(sut);


            static TheItem our_item;
            static UrlDecorator result;
            static UrlDetailAppender<TheItem> detail_appender;
            static UrlDetailAppenderFactory url_detail_appender_factory;
            static UrlDetailConfiguration<TheItem> appender_configuration;
            static UrlDetailAppender<TheItem> item_used;
            static Expression<PropertyAccessor<TheItem, object>> name_pointer;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_formatting_as_a_string : concern<UrlDecorator, DefaultUrlBuilder>
        {
            Establish c = () =>
            {
                the_result = "sdfsdfsdf";
                all_tokens = new List<KeyValuePair<string,object>>();
                Enumerable.Range(1,100).each(x => all_tokens.Add(new KeyValuePair<string,object>(x.ToString(),x)));


                url_formatting_visitor = the_dependency<UrlFormattingVisitor>();

                url_formatting_visitor.Stub(x => x.get_result()).Return(the_result);
                token_store.Stub(x => x.GetEnumerator()).Return(all_tokens.GetEnumerator());

            };


            Because b = () =>
                result = sut.ToString();


            It should_visit_all_of_the_tokens = () =>
                all_tokens.each(x => url_formatting_visitor.received(y => y.visit(x)));
  
            It should_return_the_result_of_the_tokenizing_visitor = () =>
                result.ShouldEqual(the_result);

            static string result;
            static string the_result;
            static UrlFormattingVisitor url_formatting_visitor;
            static List<KeyValuePair<string, object>> all_tokens;
        }

        public class TheItem
        {
            public string name { get; set; }
        }

        class OurBehaviour : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}