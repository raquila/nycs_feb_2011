using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public static class VisitorExtensions
    {
        public static void visit_all_items_with<ItemToVisit>(this IEnumerable<ItemToVisit> items,
                                                             Action<ItemToVisit> visitor)
        {
            foreach (var item_to_visit in items) visitor(item_to_visit);
        }

        public static void visit_all_items_with<ItemToVisit>(this IEnumerable<ItemToVisit> items,
                                                             Visitor<ItemToVisit> visitor)
        {
            items.visit_all_items_with(visitor.visit);
        }

        public static ReturnType get_the_result_of_visiting_all_items_with<ItemToVisit, ReturnType>(
            this IEnumerable<ItemToVisit> items, ValueReturningVisitor<ItemToVisit, ReturnType> visitor)
        {
            items.visit_all_items_with(visitor);
            return visitor.get_result();
        }
    }
}