using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInventory : MonoBehaviour, IInventory
    {
        public event Action OnInvenoryChange;
        
        public List<Item> Items => _items;
        
        private bool IsFull => _items.Count >= _capacity;
        
        [SerializeField] private int _capacity;

        [SerializeField] private List<Item> _items;

        private void Awake()
        {
            _items = new List<Item>();
        }

        public bool TryAddItem(Item item)
        {
            if (IsFull) return false; 
            
            _items.Add(item);
            
            OnInvenoryChange?.Invoke();
            
            return true;
        }

        public bool TryRemoveItem(int itemID)
        {
            var founded = _items.FirstOrDefault(a => a.ItemID == itemID);

            if (founded == null) return false;
            
            _items.Remove(founded);
            
            OnInvenoryChange?.Invoke();
            
            return true;
        }

        public bool TryRemoveItem(Item item)
        {
            if (!_items.Contains(item)) return false;
            
            _items.Remove(item);
            
            OnInvenoryChange?.Invoke();

            return true;
        }
    }
}