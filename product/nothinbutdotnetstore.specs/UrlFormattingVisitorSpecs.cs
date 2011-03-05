using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlFormattingVisitorSpecs
    {
        public abstract class concern : Observes<UrlFormattingVisitor,
                                            DefaultUrlFormattingVisitor>
        {
        }

        [Subject(typeof(DefaultUrlFormattingVisitor))]
        public class when_visiting_the_first_item : concern
        {
            Establish c = () =>
            {
                string_builder = new StringBuilder();
                command_name = "ViewTheDetails";
                provide_a_basic_sut_constructor_argument(string_builder);
                item = new KeyValuePair<string, object>("test", command_name);
            };

            Because b = () => 
                sut.visit(item);

            It should_add_only_the_value_of_the_item_suffixed_with_the_handler_extension = () =>
                string_builder.ToString().ShouldEqual("{0}.nyc".format_using(command_name));

            static KeyValuePair<string, object> item;
            static string result;
            static StringBuilder string_builder;
            static string command_name;
        }

        [Subject(typeof(DefaultUrlFormattingVisitor))]
        public class when_visiting_the_second_item : concern
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                builder.AppendFormat("sdfsdf.nyc");

                
                command_name = "ViewTheDetails";
                provide_a_basic_sut_constructor_argument(builder);
                the_second_item = new KeyValuePair<string, object>("test2", command_name);

            };

            Because b = () =>
                sut.visit(the_second_item);

            It should_append_the_key_value_pair_of_the_item = () =>
                builder.ToString().ShouldEndWith("?{0}={1}".format_using(the_second_item.Key, the_second_item.Value));

            static string result;
            static StringBuilder builder;
            static string command_name;
            static KeyValuePair<string, object> the_second_item;
        }
        

        public abstract class concern_for_visitor_that_has_already_visited_2_items : concern
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                builder.Append("sdfsdfsdf.nyc?item=value");
                provide_a_basic_sut_constructor_argument(builder);
            };

            protected static StringBuilder builder;
        }
    
        public class when_lots_of_items_have_been_visited : concern_for_visitor_that_has_already_visited_2_items
        {
            Establish c = () =>
            {
                the_third_item = new KeyValuePair<string, object>("sdfsf",23);
            };

            Because b = () =>
                sut.visit(the_third_item);

            It should_append_the_key_value_pair_of_the_item = () =>
                builder.ToString().ShouldEndWith("&{0}={1}".format_using(the_third_item.Key,the_third_item.Value.ToString()));

            static string result;
            static KeyValuePair<string, object> the_third_item;
        }
    }
}