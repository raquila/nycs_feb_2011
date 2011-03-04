using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Machine.Specifications.DevelopWithPassion.Extensions;

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

            Because b = () => sut.visit(item);

            It should_add_only_the_value_of_the_item_suffixed_with_the_handler_extension = () => 
                string_builder.ToString().ShouldEqual("{0}.nyc".format_using(command_name));

            static KeyValuePair<string, object> item;
            static string result;
            static StringBuilder string_builder;
            static string command_name;
        }
    }
}