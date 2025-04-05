using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Root.MaximEnvironment
{
    public class CharacterInventory : MonoBehaviour
    {
        public Item HandsItem;
        
        public List<Item> Items;
        
        public CharacterHands CharacterHands;
        
        private void Start()
        {
            Items = new List<Item>();
        }

        public void CollectItem(Item item)
        {
            if (Items.Count == 3) return;

            Items.Add(item);
            
            item.Hide();
        }

        public Item TakeItem()
        {
            if (Items.Count == 0) return null;
            
            var item = Items[Items.Count - 1];

            Items.Remove(item);
            
            return item;
        }

        public void SetHands(Item cooked)
        {
            HandsItem = cooked;
            
            HandsItem.transform.parent = CharacterHands.ItemParent;

            HandsItem.transform.localPosition = Vector3.zero;
            
            var position = HandsItem.transform.position;
            
            CharacterHands.UpdateState(CharacterHandsState.Item);
            
            HandsItem.Show(position);
            
            Debug.Log("Set hands");
        }
    }
}