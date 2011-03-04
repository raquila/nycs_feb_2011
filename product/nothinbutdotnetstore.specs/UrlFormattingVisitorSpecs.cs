 using System;
 using System.Collections.Generic;
 using System.Text;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlFormattingVisitorSpecs
    {
        public abstract class concern : Observes< UrlFormattingVisitor,
                                            DefaultUrlFormattingVisitor>
        {
        
        }

        [Subject(typeof(DefaultUrlFormattingVisitor))]
        public class when_visiting_an_item_key_pair : concern
        {
            private Establish c = () =>
                                      {
                                          string_builder = new StringBuilder();
                                          provide_a_basic_sut_constructor_argument(string_builder);
                                          item = new KeyValuePair<string, object>("test",1);
                                      };

            private Because b = () => sut.visit(item);


            private It should_format_using_visitor = () => string_builder.ToString().ShouldEqual("test=1");
            private static KeyValuePair<string, object> item;
            private static string result;
            private static StringBuilder string_builder;
        }

        
    }
}
