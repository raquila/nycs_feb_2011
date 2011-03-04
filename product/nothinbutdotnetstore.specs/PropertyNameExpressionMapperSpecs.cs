 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.specs
{   
    public class PropertyNameExpressionMapperSpecs
    {
        public abstract class concern : Observes<PropertyNameExpressionMapper,
                                            DefaultPropertyNameExpressionMapper>
        {
        
        }

        [Subject(typeof(DefaultPropertyNameExpressionMapper))]
        public class when_mapping_from_an_expression : concern
        {
            private Establish c = () =>
                                      {
                                          property_accessor = an<PropertyAccessor<ItemToTarget, string>>();
                                      };

            private Because b = () =>
                                result  = sut.map_from<ItemToTarget>(x=>x.name);

            private It should_return_the_string = () => result.ShouldEqual("name");
            private static string result;
            private static PropertyAccessor<ItemToTarget, string> property_accessor;


            public class ItemToTarget
            {
                public string name { get; set; }
            }
        }
    }
}
