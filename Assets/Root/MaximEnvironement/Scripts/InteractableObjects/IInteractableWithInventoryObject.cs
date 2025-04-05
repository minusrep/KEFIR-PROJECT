namespace Root.MaximEnvironment
{
    public interface IInteractableWithInventoryObject : IInteractableObject
    {
        void Interact(IInventory inventory);   
    }
}