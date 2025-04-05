namespace Root.MaximEnvironment
{
    public interface IInventory
    {
        bool TryAddItem(Item item);
        
        bool TryRemoveItem(int itemID);
    }
}