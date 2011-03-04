using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Machine.Specifications.DevelopWithPassion.Extensions;
using nothinbutdotnetstore.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class VisitorExtensionsSpecs
    {
        public abstract class concern : Observes
        {

        }

        public class when_processing_a_list_of_items_with_a_dynamic_visitor : concern
        {
            Establish c = () =>
            {
                visitor = x => sum ++;
                items = Enumerable.Range(1, 100).ToList();
            };

            Because b = () =>
                VisitorExtensions.visit_all_items_with(items, visitor);


            It should_process_each_item_against_the_visitor = () =>
                sum.ShouldEqual(100);


            static IList<int> items;
            static Action<int> visitor;
            static int sum;
        }

        [Subject(typeof(Enumerable))]
        public class when_processing_a_list_of_items_with_a_visitor : concern
        {
            Establish c = () =>
            {
                visitor = an<Visitor<int>>();
                items = Enumerable.Range(1, 100).ToList();
            };

            Because b = () =>
                VisitorExtensions.visit_all_items_with(items, visitor);


            It should_process_each_item_against_the_visitor = () =>
                items.each(x => visitor.received(y => y.visit(x)));


            static IList<int> items;
            static Visitor<int> visitor;
        }
        public class when_getting_the_result_of_processing_all_items_with_a_value_returning_visitor : concern
        {
            Establish c = () =>
            {
                visitor = an<ValueReturningVisitor<int,int>>();
                items = Enumerable.Range(1, 100).ToList();

                visitor.Stub(x => x.get_result()).Return(20);
            };

            Because b = () =>
                result=VisitorExtensions.get_the_result_of_visiting_all_items_with(items, visitor);


            It should_process_each_item_against_the_visitor = () =>
                items.each(x => visitor.received(y => y.visit(x)));

            It should_return_the_value_captured_by_the_visitor = () =>
                result.ShouldEqual(20);

  


            static IList<int> items;
            static ValueReturningVisitor<int,int> visitor;
            static int result;
        }
    }
}
