using System.Collections.Generic;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CookingTable : InteractiveObject
    {
        private List<Item> _items;

        [SerializeField] private List<Item> _prefabs;
        
        private void Awake()
        {
            _items = new List<Item>();
        }

        public Item TryCookItem(Item item)
        {
            _items.Add(item);

            if (_items.Count == 3)
            {
                _items.ForEach(Destroy);
                
                return Instantiate(_prefabs[Random.Range(0, _prefabs.Count)]);
            }

            return null;
        }
    }
}