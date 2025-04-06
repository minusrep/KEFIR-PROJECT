using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInputSystem : MonoBehaviour
    {
        public CharacterProvider CharacterProvider;
        
        public CharacterInteraction CharacterInteraction;

        public CharacterInventory CharacterInventory;
        
        public CharacterAudioProvider CharacterAudioProvider;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
        }

        private void Start() 
            => CharacterProvider.SetHolstered(true);

        private void Update()
        {
            CharacterProvider.SetHolstered(CharacterInventory.HandsItem != null);
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                CharacterProvider.SwitchHolstered();

                if (CharacterInventory.HandsItem != null) 
                    CharacterInventory.DropHandsItem();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (CharacterInteraction.CurrentInteractiveObject)
                {
                    case Item item:
                        
                        if (!item.Active) break;
                        
                        if (CharacterInventory.IsFull) break;
                        
                        CharacterInventory.AddItem(item);
                        
                        break;
                    
                    case DefaultTable defaultTable:

                        var toSet = CharacterInventory.HandsItem != null && defaultTable.CurrentItem == null;

                        var toGet = CharacterInventory.HandsItem == null && defaultTable.CurrentItem != null;
                        
                        if (toSet)
                        {
                            var item = CharacterInventory.HandsItem;

                            CharacterInventory.RemoveHandsItem();
                            
                            defaultTable.SetItem(item);
                            
                            break;
                        }
                        
                        if (toGet)
                        {
                            var item = defaultTable.CurrentItem;
                            
                            CharacterInventory.AddItem(item);

                            defaultTable.ClearItem();

                            break;
                        }
                        
                        break;
                    
                    case CookingTable cookingTable:

                        var toGetHandsItem = CharacterInventory.HandsItem == null && cookingTable.HandsItem != null;
                        
                        var toSetHandsItem = CharacterInventory.HandsItem != null && cookingTable.HandsItem == null && cookingTable.ItemsCount == 0;

                        var toSetItem = CharacterInventory.InventoryItems.Count > 0;
                        
                        if (toGetHandsItem)
                        {
                            var item = cookingTable.HandsItem;
                            
                            CharacterInventory.AddItem(item);

                            cookingTable.HandsItem = null;

                            break;
                        }

                        if (toSetHandsItem)
                        {
                            var item = CharacterInventory.HandsItem;

                            CharacterInventory.RemoveHandsItem();
                            
                            cookingTable.SetHandsItem(item);

                            break;
                        }

                        if (toSetItem)
                        {
                            var item = CharacterInventory.RemoveInventoryItem();
                            
                            if (item == null) break;
                            
                            cookingTable.SetInventoryItem(item);

                            break;
                        }

                        break;
                    
                    case GuestTable guestTable:

                        var readyHands = CharacterInventory.HandsItem != null;
                        
                        if (readyHands)
                        {
                        

                            
                            guestTable.SetItem(CharacterInventory.HandsItem);

                            CharacterInventory.RemoveHandsItem();
                        }
                        
                        break;
                }
            }
        }
    }
}