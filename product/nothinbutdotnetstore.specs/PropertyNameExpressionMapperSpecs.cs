using System.Linq.Expressions;
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
        public class when_mapping_the_property_name_from_an_member_expression : concern
        {
            Establish c = () =>
            {
                accessor = x => x.name;
            };

            Because b = () =>
                result = sut.map_from(accessor);

            It should_return_the_name_of_the_property = () =>
                result.ShouldEqual("name");

            static string result;
            static Expression<PropertyAccessor<ItemToTest, object>> accessor;
        }

        public class ItemToTest
        {
            public string name { get; set; }
        }
    }
}