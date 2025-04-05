using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInteraction : MonoBehaviour
    {
        public InteractiveObject CurrentInteractiveObject { get; private set; }
        
        [SerializeField] private CharacterInventory _characterInventory;
        
        [SerializeField] private float _interactDistance;
        
        public void Interact()
        {
            var interactable = DetectInteractable();
            
            if (interactable == null) return;

            switch (interactable.Type)
            {
                case InteractionType.Default:
                    break;
                
                case InteractionType.CookingTable:
                    
                    var cookingTable = interactable as CookingTable;

                    var cooked = cookingTable.TryCookItem(_characterInventory.TakeItem());

                    if (cooked != null) _characterInventory.SetHands(cooked);

                    break;
                
                case InteractionType.TakeReadyItem:
                    
                    var item = interactable as Item;
                    
                    _characterInventory.CollectItem(item);

                    break;
            }
        }

        private void Update()
            => UpdateCurrentInteractiveObject();

        private void UpdateCurrentInteractiveObject() 
            => CurrentInteractiveObject = DetectInteractable();

        private InteractiveObject DetectInteractable()
        {
            var camera = Camera.main;
            
            var origin = camera.transform.transform.position;
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hits = new RaycastHit[1];

            var count = Physics.RaycastNonAlloc(ray, hits,  _interactDistance);

            return hits[0].collider?.GetComponent<InteractiveObject>();
        }
    }
}