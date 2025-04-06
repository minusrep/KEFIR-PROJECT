using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInventory : MonoBehaviour
    {
        public int Capacity;
        
        public List<Item> InventoryItems;
        
        public Transform InventoryParent;
        
        public Item HandsItem;

        public Transform HandsParent;

        public bool IsFull => InventoryItems.Count == Capacity;

        private void Start()
        {
            InventoryItems = new List<Item>();
        }
        
        public void AddItem(Item item)
        {
            Debug.Log("Add item");
            
            switch (item.ItemType)
            {
                case ItemType.Inventory:
                    
                    if (IsFull) break;

                    InventoryItems.Add(item);
                    
                    item.Take(InventoryParent);
                    
                    break;
                
                case ItemType.Hands:

                    Debug.Log("Its hands item");
                    
                    if (HandsItem != null) return;

                    Debug.Log("Set's hands items");
                    
                    HandsItem = item;
                    
                    item.Take(HandsParent);
                    
                    break;
            }            
        }

        public void DropHandsItem()
        {
            var item = HandsItem;
            
            item.Drop();

            RemoveHandsItem();
        }

        public Item RemoveInventoryItem()
        {
            var item = InventoryItems.LastOrDefault();
            
            if (item != null) InventoryItems.Remove(item);
            
            return item;
        }

        public Item RemoveHandsItem()
        {
            var result = HandsItem;
            
            if (result == null) return null;
            
            HandsItem = null;

            return result;
        }
    }
}