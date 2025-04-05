using UnityEngine;

namespace Root.MaximEnvironment
{
    public class DefaultTable : InteractiveObject
    {
        public Transform ItemParent;

        public Item CurrentItem;
        
        public void SetItem(Item item)
        {
            CurrentItem = item;

            item.Take(ItemParent);
        }

        public void ClearItem() 
            => CurrentItem = null;
    }
}