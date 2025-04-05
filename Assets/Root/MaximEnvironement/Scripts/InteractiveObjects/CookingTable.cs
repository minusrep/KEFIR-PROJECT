using System.Collections.Generic;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CookingTable : InteractiveObject
    {
        public Item HandsItem;
        
        public Transform HandsItemParent;
        
        public List<Transform> _itemsPoints;

        public List<Item> _items;
        
        public int ItemsCount;

        public List<Item> HandsItemPrefabs;
        
        private void Start()
        {
            _items = new List<Item>();
        }

        public void SetHandsItem(Item item)
        {
            HandsItem = item;
            
            item.Take(HandsItemParent);
        }

        public void SetInventoryItem(Item item)
        {
            item.Take(_itemsPoints[ItemsCount]);
            
            _itemsPoints.Add(item.transform);

            _items.Add(item);
            
            ItemsCount++;
            
            if(ItemsCount == 3)
            {
                ClearAll();
                
                HandsItem = Instantiate(HandsItemPrefabs[Random.Range(0, HandsItemPrefabs.Count)], HandsItemParent);
            }
        }

        public void ClearAll()
        {
            if (ItemsCount == 3)
            {
                ItemsCount = 0;
                
                _items.ForEach(a => Destroy(a.gameObject));

                _items.Clear();
            }
        }
    }
}