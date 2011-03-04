 using System;
 using System.Collections.Generic;
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
                                          item = new KeyValuePair<string, object>("test",1);
                                      };

            private Because b = () =>
                                    {
                                        sut.visit(item);
                                        result = sut.get_result();
                                    };


            private It should_format_using_visitor = () => result.ShouldEqual("test=1");
            private static KeyValuePair<string, object> item;
            private static string result;
        }

        
    }
}
