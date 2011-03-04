namespace nothinbutdotnetstore.utility
{
    public interface Visitor<ItemToVisit>
    {
        void visit(ItemToVisit item);
    }
}